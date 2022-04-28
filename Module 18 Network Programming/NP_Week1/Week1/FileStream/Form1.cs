using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Add the Input/Output Library
using System.IO;

namespace FileStream
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboGender.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Write
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\" + txtName.Text + ".txt");
            
            sw.WriteLine(lblName.Text + " " + txtName.Text);
            sw.WriteLine(lblAddress.Text + " " + txtAddress.Text);
            sw.WriteLine(lblGender.Text + " " + comboGender.Text);
            sw.Close();

            // Read
            StreamReader sr = new StreamReader(Application.StartupPath + "\\" + txtName.Text + ".txt");
            txtFile.Text = sr.ReadToEnd();
            sr.Close();
            
        }

        
    }
}
