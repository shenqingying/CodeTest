using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class CNDeliveryInfo
    {
        private string _VBELN;
        private int _TYDID;
        private int _STATUS;
        private string _FILLNAME;
        private string _FILLTIME;
        private string _FILLID;

        public string VBELN
        {
            get { return _VBELN; }
            set { _VBELN = value; }
        }        

        public int TYDID
        {
            get { return _TYDID; }
            set { _TYDID = value; }
        }

        public int STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }

        public string FILLNAME
        {
            get { return _FILLNAME; }
            set { _FILLNAME = value; }
        }        

        public string FILLTIME
        {
            get { return _FILLTIME; }
            set { _FILLTIME = value; }        }
       

        public string FILLID
        {
            get { return _FILLID; }
            set { _FILLID = value; }
        }
    }
}
