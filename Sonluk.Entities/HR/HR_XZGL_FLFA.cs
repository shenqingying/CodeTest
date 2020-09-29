using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_XZGL_FLFA
    {
        private int _FLFAID;

        public int FLFAID
        {
            get { return _FLFAID; }
            set { _FLFAID = value; }
        }
        private string _FANAME;

        public string FANAME
        {
            get { return _FANAME; }
            set { _FANAME = value; }
        }
        private int _FASF;

        public int FASF
        {
            get { return _FASF; }
            set { _FASF = value; }
        }
        private string _FASFNAME;

        public string FASFNAME
        {
            get { return _FASFNAME; }
            set { _FASFNAME = value; }
        }
        private int _FACITY;

        public int FACITY
        {
            get { return _FACITY; }
            set { _FACITY = value; }
        }
        private string _FACITYNAME;

        public string FACITYNAME
        {
            get { return _FACITYNAME; }
            set { _FACITYNAME = value; }
        }
        private int _ISACTION;

        public int ISACTION
        {
            get { return _ISACTION; }
            set { _ISACTION = value; }
        }
        private string _REMARK;

        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        private int _ISDELETE;

        public int ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }
        private int _CJR;

        public int CJR
        {
            get { return _CJR; }
            set { _CJR = value; }
        }
        private string _CJRNAME;

        public string CJRNAME
        {
            get { return _CJRNAME; }
            set { _CJRNAME = value; }
        }
        private string _CJTIME;

        public string CJTIME
        {
            get { return _CJTIME; }
            set { _CJTIME = value; }
        }
        private int _XGR;

        public int XGR
        {
            get { return _XGR; }
            set { _XGR = value; }
        }
        private string _XGRNAME;

        public string XGRNAME
        {
            get { return _XGRNAME; }
            set { _XGRNAME = value; }
        }
        private string _XGTIME;

        public string XGTIME
        {
            get { return _XGTIME; }
            set { _XGTIME = value; }
        }
        private string _XZALL;

        public string XZALL
        {
            get { return _XZALL; }
            set { _XZALL = value; }
        }
        private List<HR_XZGL_FLFAMX> _HR_XZGL_FLFAMX;

        public List<HR_XZGL_FLFAMX> HR_XZGL_FLFAMX
        {
            get { return _HR_XZGL_FLFAMX; }
            set { _HR_XZGL_FLFAMX = value; }
        }
    }
}
