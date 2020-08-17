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
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (tBoxFirstName.Text != "" && tBoxLastName.Text != "" && tBoxAge.Text != "")
            {
                students.Add(new Student(tBoxFirstName.Text, tBoxLastName.Text, Convert.ToInt32(tBoxAge.Text)));
            }
            SaveFile();
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
    }
}
