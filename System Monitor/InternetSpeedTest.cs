using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using System.IO;
using System.Threading;
using System.Xml.Serialization;




namespace System_Monitor
{
    public partial class InternetSpeedTest : Form
    {

        public InternetSpeedTest()
        {
            InitializeComponent();
            string root = @"C:\Temp";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            intspdtstmr.Start();
        }
        public bool pingStatus ()
        {
            bool pingStatus = false;
            string hostNameOrAddress = "google.com";

            using(Ping p = new Ping())
            {
                string data = "pingme";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 1000;

                try
                {
                    PingReply reply = p.Send(hostNameOrAddress, timeout, buffer);
                    pingStatus = (reply.Status == IPStatus.Success);
                }
                catch(Exception)
                {
                    pingStatus = false;
                }
                return pingStatus;
            }
        }

        /*public static double Speed(string url)
        {
            WebClient wc = new WebClient();
            DateTime dt1 = DateTime.Now;
            byte[] data = wc.DownloadData(url);
            Thread.Sleep(500);
            DateTime dt2 = DateTime.Now;
            return (data.Length * 8) * (dt2 - dt1).TotalSeconds;
        }*/

        private void intspdtstmr_Tick(object sender, EventArgs e)
        {

            if (connectivitychk.verify() == true)
            {
                if (pingStatus() == true)
                {
                    var watch = new Stopwatch();


                    using (var client = new System.Net.WebClient())
                    {
                        watch.Start();
                        DateTime dt1 = DateTime.Now;
                        client.DownloadFile("http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.js", @"C:\Temp\jquery.js");
                        //client.DownloadFile("http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.js", @"C:\Temp\setup.js" + DateTime.Now.Ticks);
                        DateTime dt2 = DateTime.Now;
                        File.Delete(@"C:\Temp\jquery.js");


                        watch.Stop();
                    }

                    double speed = (261.0 / watch.Elapsed.TotalSeconds) * 8 / 1000;
                    label2.Text = Math.Round(speed, 2).ToString() + " Mbps";
                    label3.Text = "";
                }
                else
                {
                    label2.Text = "WiFi Connected";
                    label3.Text = "Internet Unavailable";
                }

            }
            else
            {
                label3.Text = "Internet Unavailable";
                label2.Text = "WiFi Disconnected";
            }

        }

    }
}
