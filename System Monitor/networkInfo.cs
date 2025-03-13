using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace System_Monitor
{
    public partial class networkInfo : Form
    {

        public networkInfo()
        {
            InitializeComponent();
            netwtmr.Start();
            
        }
        


        public static String ActiveNetworkInterface()
        {
            string Google = "google.com";
            try
            {
                UdpClient u = new UdpClient(Google, 1);
                IPAddress localAddr = ((IPEndPoint)u.Client.LocalEndPoint).Address;


                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {

                    IPInterfaceProperties ipProps = nic.GetIPProperties();
                    foreach (UnicastIPAddressInformation addrinfo in ipProps.UnicastAddresses)
                    {
                        if (localAddr.Equals(addrinfo.Address))
                        {
                            string addptrs = nic.Description;
                            string addptr = addptrs.Replace('(', '[');
                            addptr = addptr.Replace(')', ']');
                            return addptr;
                        }
                    }
                }
                return "falsei";
            }
            catch
            {
                return "false";
            }
           
            
        }

        PerformanceCounter perfNetworkSpeed = new PerformanceCounter("Network Adapter", "Bytes Received/sec", ActiveNetworkInterface());


        private void netwtmr_Tick(object sender, EventArgs e)
        {
            string netintf = ActiveNetworkInterface();
            
            try
            {
                
                if (connectivitychk.verify() == false)
                {
                    label1.Text = "Download Speed : " + " " + "0" + " " + "Mb/s";
                    label2.Text = "Network Interface : " + " " + "No Active Interface";
                    
                }

                else if (connectivitychk.verify() == true && netintf == "false")
                {
                    label1.Text = "Download Speed : " + " ";
                    label2.Text = "Network Interface : " + " ";
                    
                }


                else
                {

                label1.Text = "Download Speed : " + " " + (int)perfNetworkSpeed.NextValue() * 8 / 1000 / 1000 + " " + "Mb/s";
                label2.Text = "Network Interface : " + " " + netintf;

                }
            }
            catch
            {
                label2.Text = "No Internet";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Application.Restart();
            

        }
    }
}
