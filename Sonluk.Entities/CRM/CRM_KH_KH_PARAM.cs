using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_KH_KH_PARAM
    {
        int _KHLX;

        public int KHLX
        {
            get { return _KHLX; }
            set { _KHLX = value; }
        }
        int _KHID;

        public int KHID
        {
            get { return _KHID; }
            set { _KHID = value; }
        }
        string _MC;

        public string MC
        {
            get { return _MC; }
            set { _MC = value; }
        }
        string _SAPSN;

        public string SAPSN
        {
            get { return _SAPSN; }
            set { _SAPSN = value; }
        }
        int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        double _JD;

        public double JD
        {
            get { return _JD; }
            set { _JD = value; }
        }
        double _WD;

        public double WD
        {
            get { return _WD; }
            set { _WD = value; }
        }
        int _MULTIPLE;

        public int MULTIPLE
        {
            get { return _MULTIPLE; }
            set { _MULTIPLE = value; }
        }
    }
}
