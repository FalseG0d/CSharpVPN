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
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                if (radioButton1.Checked)
                {
                    startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                    //Choose The Path To Required OpenVPN.exe file
                    startInfo.Arguments = "--config server.ovpn";
                    startInfo.Verb = "runas";

                    process.StartInfo = startInfo;
                    process.Start();
                    MessageBox.Show("You Have Been Connected To the Server with UDP");
                }
                else if (radioButton2.Checked)
                {
                    startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                    //Choose The Path To Required OpenVPN.exe file
                    startInfo.Arguments = "--config server.ovpn";
                    startInfo.Verb = "runas";

                    process.StartInfo = startInfo;
                    process.Start();
                    MessageBox.Show("You Have Been Connected To the Server with FTP");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            disconnect();
            MessageBox.Show("You Have Been Disconnected From The Server.")
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
    }
}
