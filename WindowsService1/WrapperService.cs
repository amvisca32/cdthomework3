///
/// WrapperService.cs
/// CDT Homework #3
/// Author: Adrianna Visca
/// 

using System;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace WindowsService1
{
    /// <summary>
    /// Contains methods for starting, stopping, and recalling
    /// a windows service. Uses the base class ServiceBase.
    /// </summary>
    public partial class WrapperService : ServiceBase
    {
            Timer timer = new Timer(); // name space(using System.Timers;) 
            
            /// <summary>
            /// Constructor for the WrapperService that calls InializeCompnent method
            /// which is the required method for designer support.
            /// </summary>
            public WrapperService()
            { 
                InitializeComponent();
            }

            /// <summary>
            /// Called when the service is started either from the command line or
            /// from the Services GUI. Writes what time the service was started in the log
            /// file and sets the recall time to 5 seconds.
            /// </summary>
            protected override void OnStart(string[] args)
            {
                WriteToFile("Service is started at " + DateTime.Now);
                timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
                timer.Interval = 5000; //number in milisecinds  
                timer.Enabled = true;
            }

            /// <summary>
            /// Called when the service is stopped either from the command line or
            /// from the Services GUI. Writes what time the service was stopped in the log
            /// file.
            /// </summary>
            protected override void OnStop()
            {
                WriteToFile("Service is stopped at " + DateTime.Now);
            }

            /// <summary>
            /// Called every 5 seconds when the service is recalled. Writes what time the 
            /// service was recalled in the log file.
            /// </summary>
            private void OnElapsedTime(object source, ElapsedEventArgs e)
            {
            WriteToFile("Service is recall at " + DateTime.Now);
            }

            /// <summary>
            /// Function to write to the log file within the debug file using the message
            /// provided as a parameter.
            /// </summary>
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

