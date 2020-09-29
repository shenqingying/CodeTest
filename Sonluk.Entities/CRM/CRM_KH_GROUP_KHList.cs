using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_KH_GROUP_KHList
    {
        int _GID;

        public int GID
        {
            get { return _GID; }
            set { _GID = value; }
        }
        int _KHID;

        public int KHID
        {
            get { return _KHID; }
            set { _KHID = value; }
        }
        string _GIDDES;

        public string GIDDES
        {
            get { return _GIDDES; }
            set { _GIDDES = value; }
        }
        string _KHIDDES;

        public string KHIDDES
        {
            get { return _KHIDDES; }
            set { _KHIDDES = value; }
        }
        string _CRMID;

        public string CRMID
        {
            get { return _CRMID; }
            set { _CRMID = value; }
        }
        string _JXSMC;

        public string JXSMC
        {
            get { return _JXSMC; }
            set { _JXSMC = value; }
        }
        string _JXSCRMID;

        public string JXSCRMID
        {
            get { return _JXSCRMID; }
            set { _JXSCRMID = value; }
        }
        string _JXSSAPSN;

        public string JXSSAPSN
        {
            get { return _JXSSAPSN; }
            set { _JXSSAPSN = value; }
        }
    }
}
