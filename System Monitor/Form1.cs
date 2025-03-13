using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace System_Monitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var spdtstform = new InternetSpeedTest();
            spdtstform.StartPosition = FormStartPosition.CenterScreen;
            spdtstform.ShowDialog();
            this.Show();

            /*var spdtstform = new InternetSpeedTest();
            spdtstform.Show();*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var cpuform = new CPUInfo();
            cpuform.StartPosition = FormStartPosition.CenterScreen;
            cpuform.ShowDialog();
            this.Show();

            /*var cpuform = new CPUInfo();
            cpuform.Show();*/

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var memform = new memoryInfo();
            memform.StartPosition = FormStartPosition.CenterScreen;
            memform.ShowDialog();
            this.Show();

            /*var memform = new memoryInfo();
            memform.Show();*/

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var netform = new networkInfo();
            netform.StartPosition = FormStartPosition.CenterScreen;
            netform.ShowDialog();
            try
            {
                this.Show();
            }
            catch(Exception)
            {

            }

            /*var netform = new networkInfo();
            netform.Show();*/

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var tempform = new temperatures();
            tempform.StartPosition = FormStartPosition.CenterScreen;
            tempform.ShowDialog();
            this.Show();

            /*var discinform = new discinfo();
            discinform.Show();*/

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            var sysform = new SystemInfo();
            sysform.StartPosition = FormStartPosition.CenterScreen;
            sysform.ShowDialog();
            this.Show();

            /*var sysform = new SystemInfo();
            sysform.Show();*/

        }
    }
}
