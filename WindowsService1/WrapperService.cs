﻿using System;
using System.IO;
using System.ServiceProcess;
using System.Timers;
using System.Windows.Forms;

namespace WindowsService1
{
    public partial class WrapperService : ServiceBase
    {
            System.Timers.Timer timer = new System.Timers.Timer(); // name space(using System.Timers;) 
            //KeyboardActions key = new KeyboardActions();
            public WrapperService()
            { 
                InitializeComponent();
            }

            protected override void OnStart(string[] args)
            {
                WriteToFile("Service is started at " + DateTime.Now);
                timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
                timer.Interval = 20000; //5000; number in milisecinds  
                timer.Enabled = true;
            }

            protected override void OnStop()
            {
                WriteToFile("Service is stopped at " + DateTime.Now);
            }

            private void OnElapsedTime(object source, ElapsedEventArgs e)
            {
                WriteToFile("Service is recall at " + DateTime.Now);
                //string text = "Shark";
                //MessageBox.Show(text);
                DisplayMessageBoxText();
            }

            private void DisplayMessageBoxText()
            {
                MessageBox.Show("Hello, world.");
            }


        public void WriteToFile(string Message)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
                if (!File.Exists(filepath))
                {
                    // Create a file to write to.   
                    using (StreamWriter sw = File.CreateText(filepath))
                    {
                        sw.WriteLine(Message);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLine(Message);
                    }
                }
            }
    }
}