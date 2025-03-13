using Microsoft.VisualBasic.Devices;
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
using OpenHardwareMonitor.Hardware;
using Computer = OpenHardwareMonitor.Hardware.Computer;

namespace System_Monitor
{
    public partial class temperatures : Form
    {
        
        public temperatures()
        {
            InitializeComponent();
            temptimer.Start();
        }

        /*public double Tmprs()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");
            double tmps = 0;
            foreach (ManagementObject obj in searcher.Get())
            {
                tmps = Convert.ToDouble(obj["CurrentTemperature"].ToString());
                tmps = (tmps - 2732) / 10.0;
            }
            return tmps;
        }*/
        public void GpuPwr()
        {
            Computer c = new Computer()
            {
                GPUEnabled = true
            };
            c.Open();
            foreach(var hardware in c.Hardware)
            {
                if(hardware.HardwareType == HardwareType.GpuAti || hardware.HardwareType == HardwareType.GpuNvidia)
                {
                    hardware.Update();
                    foreach(var sensors in hardware.Sensors)
                    {
                        if (sensors.SensorType == SensorType.Load && sensors.Name.Contains("GPU Core"))
                        {
                            label8.Text = sensors.Value.GetValueOrDefault().ToString() + " %";
                        }
                        else if (sensors.SensorType == SensorType.Temperature && sensors.Name.Contains("GPU Core"))
                        {
                            label10.Text = sensors.Value.GetValueOrDefault().ToString() + " °C";
                        }
                        else if(sensors.SensorType == SensorType.Clock && sensors.Name.Contains("GPU Core"))
                        {
                            label12.Text = sensors.Value.GetValueOrDefault().ToString() + " MHz";
                        }
                        else if (sensors.SensorType == SensorType.Clock && sensors.Name.Contains("GPU Memory"))
                        {
                            label14.Text = sensors.Value.GetValueOrDefault().ToString() + " MHz";
                        }
                    }
                }
            }
        }
        public void RamPwr()
        {
            Computer c = new Computer()
            {
                RAMEnabled = true
            };
            c.Open();
            foreach (var hardware in c.Hardware)
            {
                if (hardware.HardwareType == HardwareType.RAM)
                {
                    hardware.Update();
                    foreach (var sensors in hardware.Sensors)
                    {
                        if (sensors.SensorType == SensorType.Load)
                        {
                            //tempers = 
                            //pwer = Math.Round(sensors.Value.GetValueOrDefault(),0);
                            label6.Text = Math.Round(sensors.Value.GetValueOrDefault(), 0).ToString() + " %";


                        }
                    }
                }
            }
        }
        public void CpuPwr()
        {
            
            Computer c = new Computer()
            {
                CPUEnabled = true
            };
            c.Open();
            foreach(var hardware in c.Hardware)
            {
                if(hardware.HardwareType == HardwareType.CPU)
                {
                    hardware.Update();
                    foreach(var sensors in hardware.Sensors)
                    {
                        if (sensors.SensorType == SensorType.Power && sensors.Name.Contains("CPU Package"))
                        {
                            //tempers = 
                            //pwer = Math.Round(sensors.Value.GetValueOrDefault(),0);
                            label4.Text = Math.Round(sensors.Value.GetValueOrDefault(), 0).ToString() + " W";
                            

                        }
                        if (sensors.SensorType == SensorType.Temperature && sensors.Name.Contains("CPU Package"))
                        {
                            //tempers = 
                            //pwer = Math.Round(sensors.Value.GetValueOrDefault(),0);
                            label2.Text = Math.Round(sensors.Value.GetValueOrDefault(), 0).ToString() + " °C";


                        }
                    }
                }
            }
            //return pwer;
        }
        /*public void Fans()
        {
            Computer c = new Computer();
            c.FanControllerEnabled = true;
            c.MainboardEnabled = true;
            c.Open();
            foreach (var hardware in c.Hardware)
            {
                if (hardware.HardwareType == HardwareType.SuperIO)
                {
                    hardware.Update();
                    foreach (var sensors in hardware.Sensors)
                    {
                        if (sensors.SensorType == SensorType.Fan)
                        {
                            label15.Text = sensors.Value.GetValueOrDefault().ToString();
                        }
                    }
                }
            }
        }*/

        private void temptimer_Tick(object sender, EventArgs e)
        {
            //label2.Text = Tmprs().ToString() + " °C";
            //label4.Text = CpuPwr().pwer.ToString() + " W";
            CpuPwr();
            RamPwr();
            GpuPwr();
            //Fans();
        }
    }
}
