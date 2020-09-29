using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.Common
{
    public class LogInfo
    {
        private string _Date;
        private string _Title;
        private string _Content;

        public LogInfo()
        {
        }

        public LogInfo(string date,string title, string content)
        {
            _Date = date;
            _Title = title;
            _Content = content;
        }

        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }
    }
}
