using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCS_StudentContactsJson
{
    public partial class Form1 : Form
    {
        List<Student> students = new List<Student>();

        public Form1()
        {
            InitializeComponent();
            LoadFile();
            dataGridView1.ClearSelection();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (tBoxFirstName.Text != "" && tBoxLastName.Text != "" && tBoxAge.Text != "")
            {
                students.Add(new Student(tBoxFirstName.Text, tBoxLastName.Text, Convert.ToInt32(tBoxAge.Text)));
            }
            ClearBoxes();
            DisplayInGrid();
        }

        private void SaveFile()
        {
            FileIO.SaveToFile(students);
        }

        private void LoadFile()
        {
            students = FileIO.LoadFromFile();
            DisplayInGrid();
        }

        private void ClearBoxes()
        {
            tBoxFirstName.Text = "";
            tBoxLastName.Text = "";
            tBoxAge.Text = "";
        }

        private void DisplayInGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (var student in students)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = student.name;
                dataGridView1.Rows[n].Cells[1].Value = student.lastName;
                dataGridView1.Rows[n].Cells[2].Value = student.age.ToString();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DisplayDataRow();
        }

        private void DisplayDataRow()
        {
            tBoxFirstName.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            tBoxLastName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            tBoxAge.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected) < 1 ||
                tBoxFirstName.Text == "" || tBoxLastName.Text == "" || tBoxAge.Text == "")
                return;
            
            int selectedStudentIndex = dataGridView1.SelectedRows[0].Index;
            students[selectedStudentIndex].name = tBoxFirstName.Text;
            students[selectedStudentIndex].lastName = tBoxLastName.Text;
            students[selectedStudentIndex].age = Convert.ToInt32(tBoxAge.Text);
            DisplayInGrid();
            ClearBoxes();           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected) < 1 ||
                tBoxFirstName.Text == "" || tBoxLastName.Text == "" || tBoxAge.Text == "")
                return;

            int selectedStudentIndex = dataGridView1.SelectedRows[0].Index;
            students.RemoveAt(selectedStudentIndex);
            DisplayInGrid();
            ClearBoxes();
        }
    }
}
