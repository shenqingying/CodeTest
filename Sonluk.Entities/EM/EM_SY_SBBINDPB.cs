using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_SBBINDPB
    {
        private string _SBBH;  //单机设备编号

        public string SBBH
        {
            get { return _SBBH; }
            set { _SBBH = value; }
        }
        private int _PBID;  //安卓平板

        public int PBID
        {
            get { return _PBID; }
            set { _PBID = value; }
        }
        private string _SBMS;

        public string SBMS
        {
            get { return _SBMS; }
            set { _SBMS = value; }
        }
        private int _SJ;

        public int SJ
        {
            get { return _SJ; }
            set { _SJ = value; }
        }
        private string _MACIP;

        public string MACIP
        {
            get { return _MACIP; }
            set { _MACIP = value; }
        }
        string _IMAGEID;

        public string IMAGEID
        {
            get { return _IMAGEID; }
            set { _IMAGEID = value; }
        }
        int _JG;

        public int JG
        {
            get { return _JG; }
            set { _JG = value; }
        }
        string _REMARK1;

        public string REMARK1
        {
            get { return _REMARK1; }
            set { _REMARK1 = value; }
        }
        string _REMARK2;

        public string REMARK2
        {
            get { return _REMARK2; }
            set { _REMARK2 = value; }
        }
        string _TXTYPENAME;

        public string TXTYPENAME
        {
            get { return _TXTYPENAME; }
            set { _TXTYPENAME = value; }
        }

    }
}
