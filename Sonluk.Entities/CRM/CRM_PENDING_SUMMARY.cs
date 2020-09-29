using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_PENDING_SUMMARY
    {
        string _SUMMARYDES;

        public string SUMMARYDES
        {
            get { return _SUMMARYDES; }
            set { _SUMMARYDES = value; }
        }
        int _SUMMARYID;

        public int SUMMARYID
        {
            get { return _SUMMARYID; }
            set { _SUMMARYID = value; }
        }
        //int _STAFFID;

        //public int STAFFID
        //{
        //    get { return _STAFFID; }
        //    set { _STAFFID = value; }
        //}
        int _KHCOUNTS;

        public int KHCOUNTS
        {
            get { return _KHCOUNTS; }
            set { _KHCOUNTS = value; }
        }
        int _FINISHCOUNTS;

        public int FINISHCOUNTS
        {
            get { return _FINISHCOUNTS; }
            set { _FINISHCOUNTS = value; }
        }
        int _REQUIRECOUNTS;

        public int REQUIRECOUNTS
        {
            get { return _REQUIRECOUNTS; }
            set { _REQUIRECOUNTS = value; }
        }
        int _UNFINISHEDCOUNTS;

        public int UNFINISHEDCOUNTS
        {
            get { return _UNFINISHEDCOUNTS; }
            set { _UNFINISHEDCOUNTS = value; }
        }

     
    }
}
