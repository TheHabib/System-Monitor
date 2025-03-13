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
    public partial class CPUInfo : Form
    {
        PerformanceCounter perfCPUCounter = new PerformanceCounter("Processor Information", "% Processor Utility", "_Total");
        PerformanceCounter perfSystemCounter = new PerformanceCounter("System", "System Up Time");
        PerformanceCounter cpuCounter = new PerformanceCounter("Processor Information", "% Processor Performance", "_Total");

        public CPUInfo()
        {
            InitializeComponent();
            
            cpuinfotmr.Start();
        }

        private void cpuinfotmr_Tick(object sender, EventArgs e)
        {
            label1.Text = "CPU : " + " " + ((int)perfCPUCounter.NextValue()) + " " + "%";

            float sysUptime = (int)perfSystemCounter.NextValue() / 60 / 60;

            if (sysUptime < 1)
            {
                label2.Text = "System Up Time : " + " " + (int)perfSystemCounter.NextValue() / 60 + " " + "Minutes";
            }
            else
            {
                label2.Text = "System Up Time : " + " " + (int)perfSystemCounter.NextValue() / 60 / 60 + " " + "Hours";
            }

            ManagementObjectSearcher baseclocksearcher = new ManagementObjectSearcher("select MaxClockSpeed from Win32_Processor");
            foreach (ManagementObject tmbaseclock in baseclocksearcher.Get())
            {
                double cpuValue = cpuCounter.NextValue();

                double baseclockSpeed = (Convert.ToDouble(tmbaseclock["MaxClockSpeed"]));

                double tmpbaseclkspd = baseclockSpeed / 1000;
                double bseclkspd = Math.Round(tmpbaseclkspd, 2);
                label3.Text = "Base CPU Speed : " + " " + bseclkspd + " " + "GHz";

                double turboSpeed = bseclkspd * cpuValue / 100;
                turboSpeed = Math.Round(turboSpeed, 2);

                label4.Text = "Current CPU Speed : " + " " + turboSpeed + " " + "GHz";


            }

        }
    }
}
