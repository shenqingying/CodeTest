using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_KH_BankList
    {
        int _FID;

        public int FID
        {
            get { return _FID; }
            set { _FID = value; }
        }
        string _FIDDES;

        public string FIDDES
        {
            get { return _FIDDES; }
            set { _FIDDES = value; }
        }
        int _DICID;

        public int DICID
        {
            get { return _DICID; }
            set { _DICID = value; }
        }
        string _DICIDDES;

        public string DICIDDES
        {
            get { return _DICIDDES; }
            set { _DICIDDES = value; }
        }
        string _MC;

        public string MC
        {
            get { return _MC; }
            set { _MC = value; }
        }
        string _CRMID;

        public string CRMID
        {
            get { return _CRMID; }
            set { _CRMID = value; }
        }
        string _HTXSRW;

        public string HTXSRW
        {
            get { return _HTXSRW; }
            set { _HTXSRW = value; }
        }
        string _XXMC;

        public string XXMC
        {
            get { return _XXMC; }
            set { _XXMC = value; }
        }
        int _ISACTIVE;

        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }
    }
}
