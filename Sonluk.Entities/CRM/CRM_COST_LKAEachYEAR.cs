using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_COST_LKAEachYEAR
    {
        int _EACHID;

        public int EACHID
        {
            get { return _EACHID; }
            set { _EACHID = value; }
        }
        int _LKAYEARTTID;

        public int LKAYEARTTID
        {
            get { return _LKAYEARTTID; }
            set { _LKAYEARTTID = value; }
        }
        int _KHID;

        public int KHID
        {
            get { return _KHID; }
            set { _KHID = value; }
        }
        string _HTYEAR;

        public string HTYEAR
        {
            get { return _HTYEAR; }
            set { _HTYEAR = value; }
        }
        int _MONTHCOUNT;

        public int MONTHCOUNT
        {
            get { return _MONTHCOUNT; }
            set { _MONTHCOUNT = value; }
        }
        decimal _FY;

        public decimal FY
        {
            get { return _FY; }
            set { _FY = value; }
        }

        decimal _CCJ;

        public decimal CCJ
        {
            get { return _CCJ; }
            set { _CCJ = value; }
        }
        int _ISACTIVE;

        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }





    }
}
