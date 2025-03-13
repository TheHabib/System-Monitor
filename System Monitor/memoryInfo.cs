using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Monitor
{
    public partial class memoryInfo : Form
    {
        //PerformanceCounter perfMemCounter = new PerformanceCounter("Memory", "Available MBytes");
        public memoryInfo()
        {
            InitializeComponent();
            memtmr.Start();
        }

        private void memtmr_Tick(object sender, EventArgs e)
        {

            /*ManagementObjectSearcher totalram = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");
            foreach (ManagementObject Mobject in totalram.Get())
            {
                double tmramSize = (Convert.ToDouble(Mobject["TotalPhysicalMemory"]));
                tmramSize = tmramSize/1024/1024/1024;
                double ramSize = Math.Round(tmramSize, 1);
                label1.Text = "Total Memory : " + " " + ramSize + " " + "GB";
                label3.Text = "Used Memory : " + " " + Math.Round((((ramSize * 1024) - (double)perfMemCounter.NextValue())) / 1024, 1) + " " + "MB";
            }
            label2.Text = "Available Memory : " + " " + (int)perfMemCounter.NextValue() + " " + "MB";*/

            Computer c = new Computer();
            double tmramSize = c.Info.TotalPhysicalMemory;
            tmramSize = tmramSize / 1024 / 1024 / 1024;
            double ramSize = Math.Round(tmramSize, 1);
            label1.Text = "Total Memory : " + " " + ramSize + " " + "GB";
            label3.Text = "Used Memory : " + " " + Math.Round((((ramSize * 1024) - (double)(c.Info.AvailablePhysicalMemory/1024/1024))) / 1024, 1) + " " + "GB";
            label2.Text = "Available Memory : " + " " + Math.Round((double)(c.Info.AvailablePhysicalMemory) / 1024 / 1024, 0) + " " + "MB";

        }
    }
}
