using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_KH_HDList : CRM_KH_HD
    {
        string _HDMCDES;

        public string HDMCDES
        {
            get { return _HDMCDES; }
            set { _HDMCDES = value; }
        }
        string _CPLXDES;

        public string CPLXDES
        {
            get { return _CPLXDES; }
            set { _CPLXDES = value; }
        }
        string _CZRDES;

        public string CZRDES
        {
            get { return _CZRDES; }
            set { _CZRDES = value; }
        }
        string _KHMC;

        public string KHMC
        {
            get { return _KHMC; }
            set { _KHMC = value; }
        }
        string _HDTCDES;

        public string HDTCDES
        {
            get { return _HDTCDES; }
            set { _HDTCDES = value; }
        }
        string _HDCLDES;

        public string HDCLDES
        {
            get { return _HDCLDES; }
            set { _HDCLDES = value; }
        }
        int _IMGCOUNT;

        public int IMGCOUNT
        {
            get { return _IMGCOUNT; }
            set { _IMGCOUNT = value; }
        }


    }
}
