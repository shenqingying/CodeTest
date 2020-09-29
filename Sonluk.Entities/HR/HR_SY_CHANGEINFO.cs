using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_SY_CHANGEINFO
    {
        private string _CHANGETIMEKS;

        public string CHANGETIMEKS
        {
            get { return _CHANGETIMEKS; }
            set { _CHANGETIMEKS = value; }
        }
        private string _CHANGETIMEJS;

        public string CHANGETIMEJS
        {
            get { return _CHANGETIMEJS; }
            set { _CHANGETIMEJS = value; }
        }
        private string _CHANGESY;

        public string CHANGESY
        {
            get { return _CHANGESY; }
            set { _CHANGESY = value; }
        }
        private string _CHANGETABLE;

        public string CHANGETABLE
        {
            get { return _CHANGETABLE; }
            set { _CHANGETABLE = value; }
        }
    }
}
