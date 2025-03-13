using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_Monitor
{
    public partial class SystemInfo : Form
    {
        public SystemInfo()
        {
            InitializeComponent();
            ComputerInfo cinfo = new ComputerInfo();
            label1.Text = "OS : " + " " + cinfo.OSFullName;

            if(Environment.Is64BitOperatingSystem==true)
            {
                label2.Text = "OS Platform : " + " " + "64 Bit";
            }
            else if (Environment.Is64BitOperatingSystem == false)
            {
                label2.Text = "OS Platform : " + " " + "32 Bit";
            }

            //label3.Text = "OS Version : " + " " + RuntimeInformation.OSDescription.ToString();
            var oss = Environment.OSVersion;

            //label4.Text = Microsoft.DotNet.PlatformAbstractions.RuntimeEnvironment.OperatingSystem + " " + Microsoft.DotNet.PlatformAbstractions.RuntimeEnvironment.OperatingSystemVersion;


            label5.Text = "OS Language : " + " " + cinfo.InstalledUICulture;

            var regos = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            label3.Text = "OS Version : " + " " + regos.GetValue("DisplayVersion");
            label4.Text = "OS Build : " + " " + regos.GetValue("CurrentBuild");

            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            foreach (ManagementObject mo in mc.GetInstances())
            {
                string sysmanufacturer = mo["Manufacturer"].ToString();
                string sysmodel = mo["Model"].ToString();

                label6.Text = "System Manufacturer : " + " " + sysmanufacturer;
                label7.Text = "System Model : " + " " + sysmodel;
                label9.Text = "Processor Architecture : " + " " + mo["SystemType"];

            }

            var regcpu = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0");
            label8.Text = "Processor Model : " + " " + regcpu.GetValue("ProcessorNameString");
            
            var regtimezone = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\TimeZoneInformation");
            label10.Text = "Time Zone : " + " " + regtimezone.GetValue("TimeZoneKeyName");

        }


    }
}
