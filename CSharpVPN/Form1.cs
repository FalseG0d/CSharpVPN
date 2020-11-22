using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace CSharpVPN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Server")
            {
                if (radioButton1.Checked)
                {
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    //startInfo.FileName=
                    string path = Directory.GetCurrentDirectory();
                    Console.WriteLine(path);
                }
                else if (radioButton2.Checked)
                {

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
