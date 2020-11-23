using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace CSharpVPN
{
    public partial class Form1 : Form
    {
        String path;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Server")
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;

                startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                //Choose The Path To Required OpenVPN.exe file
                startInfo.Arguments = "--config "+this.path;
                startInfo.Verb = "runas";

                process.StartInfo = startInfo;
                try
                {
                    process.Start();
                    MessageBox.Show("You Have Been Connected To the Server");
                }catch(Exception error)
                {
                    MessageBox.Show("Some Error Has Occured: " , error.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            disconnect();
            MessageBox.Show("You Have Been Disconnected From The Server.");
        }

        private void disconnect()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName="taskkill",
                Arguments=$"/f /im openvpn.exe",
                CreateNoWindow=true,
                UseShellExecute=false
            }).WaitForExit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                label2.Text=openFileDialog1.FileName;
                this.path = label2.Text;

                MessageBox.Show("File Selected");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.com");
        }
    }
}
