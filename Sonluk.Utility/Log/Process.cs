using Sonluk.Entities.Common;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Sonluk.Utility.Log
{
    public class Process
    {
        private Queues _Queues;
        private static string _Path;

        public static void Start(Queues queues)
        {
            Task.Factory.StartNew(new Process(queues).Run);
        }

        protected Process(Queues queues)
        {
            _Queues = queues;
            _Path = AppDomain.CurrentDomain.BaseDirectory + "/Logs/";
            if (!Directory.Exists(_Path))
            {
                Directory.CreateDirectory(_Path);
            }
        }

        protected void Run()
        {
            while (true)
            {
                if (_Queues.IsDocumentAvailable)
                {
                    LogInfo log = _Queues.Get();
                    try
                    {
                        string path = _Path + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
                        using (StreamWriter logFileWriter = File.AppendText(path))
                        {
                            logFileWriter.WriteLine(log.Date + " " + log.Title);
                            logFileWriter.WriteLine(log.Content);
                        }
                    }
                    catch
                    {


                    }
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }
    }

}
