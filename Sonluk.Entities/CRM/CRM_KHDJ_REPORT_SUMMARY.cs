using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_KHDJ_REPORT_SUMMARY
    {
        string _KHMC;

        public string KHMC
        {
            get { return _KHMC; }
            set { _KHMC = value; }
        }
        int _KHID;

        public int KHID
        {
            get { return _KHID; }
            set { _KHID = value; }
        }
        int _REQUIRECOUNTS;

        public int REQUIRECOUNTS
        {
            get { return _REQUIRECOUNTS; }
            set { _REQUIRECOUNTS = value; }
        }
        int _FINISHCOUNTS;

        public int FINISHCOUNTS
        {
            get { return _FINISHCOUNTS; }
            set { _FINISHCOUNTS = value; }
        }
        int _UNFINISHEDCOUNTS;

        public int UNFINISHEDCOUNTS
        {
            get { return _UNFINISHEDCOUNTS; }
            set { _UNFINISHEDCOUNTS = value; }
        }
        string _JHMS;

        public string JHMS
        {
            get { return _JHMS; }
            set { _JHMS = value; }
        }
        int _BFLX;

        public int BFLX
        {
            get { return _BFLX; }
            set { _BFLX = value; }
        }
        int _BFJHID;

        public int BFJHID
        {
            get { return _BFJHID; }
            set { _BFJHID = value; }
        }
        string _BFLXDES;

        public string BFLXDES
        {
            get { return _BFLXDES; }
            set { _BFLXDES = value; }
        }

    }
}
