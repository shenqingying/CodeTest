using Sonluk.Entities.Common;
using System.Collections.Generic;

namespace Sonluk.Utility.Log
{
    public class Queues 
    {
        private readonly Queue<LogInfo> _Queue = new Queue<LogInfo>();

        public void Add(LogInfo log)
        {
            lock (this)
            {
                _Queue.Enqueue(log);
            }
        }

        public LogInfo Get()
        {
            LogInfo log = null;
            lock (this)
            {
                log = _Queue.Dequeue();
            }
            return log;
        }

        public bool IsDocumentAvailable
        {
            get
            {
                return _Queue.Count > 0;
            }
        }
    }

}
