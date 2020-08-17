using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCS_StudentToFile
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
        }

        private void SaveFile()
        {
            FileIO.SaveToFile(students);
        }

        private void LoadFile()
        {
            students = FileIO.LoadFromFile();
        }

        private void ClearBoxes()
        {
            tBoxFirstName.Text = "";
            tBoxLastName.Text = "";
            tBoxAge.Text = "";
        }


    }
}
