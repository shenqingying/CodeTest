using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_PRODUCT_KHGROUP
    {
        int _KHID;

        public int KHID
        {
            get { return _KHID; }
            set { _KHID = value; }
        }
        int _GROUPID;

        public int GROUPID
        {
            get { return _GROUPID; }
            set { _GROUPID = value; }
        }
        string _KHLXDES;

        public string KHLXDES
        {
            get { return _KHLXDES; }
            set { _KHLXDES = value; }
        }
        string _KHMC;

        public string KHMC
        {
            get { return _KHMC; }
            set { _KHMC = value; }
        }
        string _CRMID;

        public string CRMID
        {
            get { return _CRMID; }
            set { _CRMID = value; }
        }
        string _SAPSN;

        public string SAPSN
        {
            get { return _SAPSN; }
            set { _SAPSN = value; }
        }
        string _GROUPNAME;

        public string GROUPNAME
        {
            get { return _GROUPNAME; }
            set { _GROUPNAME = value; }
        }
        string _GROUPDES;

        public string GROUPDES
        {
            get { return _GROUPDES; }
            set { _GROUPDES = value; }
        }



    }
}
