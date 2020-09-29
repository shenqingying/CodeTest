using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_BF_STAFFList
    {
        //int _STAFFID;
        //int _DEPID;
        //string _DEPDES;
        //string _STAFFNO;
        //int _STAFFLX;
        //string _STAFFDES;
        //string _STAFFNAME;
        //int _BFPC;
        //string _BFPCDES;
        int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        int _DEPID;

        public int DEPID
        {
            get { return _DEPID; }
            set { _DEPID = value; }
        }
        string _DEPDES;

        public string DEPDES
        {
            get { return _DEPDES; }
            set { _DEPDES = value; }
        }
        string _STAFFNO;

        public string STAFFNO
        {
            get { return _STAFFNO; }
            set { _STAFFNO = value; }
        }
        int _STAFFLX;

        public int STAFFLX
        {
            get { return _STAFFLX; }
            set { _STAFFLX = value; }
        }
        string _STAFFLXDES;

        public string STAFFLXDES
        {
            get { return _STAFFLXDES; }
            set { _STAFFLXDES = value; }
        }

        
        string _STAFFNAME;

        public string STAFFNAME
        {
            get { return _STAFFNAME; }
            set { _STAFFNAME = value; }
        }
        int _BFPC;

        public int BFPC
        {
            get { return _BFPC; }
            set { _BFPC = value; }
        }
        string _BFPCDES;

        public string BFPCDES
        {
            get { return _BFPCDES; }
            set { _BFPCDES = value; }
        }
    }
}
