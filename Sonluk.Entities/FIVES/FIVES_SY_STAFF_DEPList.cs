using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_STAFF_DEPList
    {
        private int _STAFFID;  //人员ID

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        private int _DEPID;  //部门ID

        public int DEPID
        {
            get { return _DEPID; }
            set { _DEPID = value; }
        }
        private int _XJSTATUS;  //巡检状态

        public int XJSTATUS
        {
            get { return _XJSTATUS; }
            set { _XJSTATUS = value; }
        }
        private int _CJSTATUS;  //抽检状态

        public int CJSTATUS
        {
            get { return _CJSTATUS; }
            set { _CJSTATUS = value; }
        }
        string _SNAME;

        public string SNAME
        {
            get { return _SNAME; }
            set { _SNAME = value; }
        }
        string _DNAME;

        public string DNAME
        {
            get { return _DNAME; }
            set { _DNAME = value; }
        }
        int _XID;

        public int XID
        {
            get { return _XID; }
            set { _XID = value; }
        }
        int _CID;

        public int CID
        {
            get { return _CID; }
            set { _CID = value; }
        }
        string _XNAME;

        public string XNAME
        {
            get { return _XNAME; }
            set { _XNAME = value; }
        }
        string _CNAME;

        public string CNAME
        {
            get { return _CNAME; }
            set { _CNAME = value; }
        }
        int _TZSTATUS;

        public int TZSTATUS
        {
            get { return _TZSTATUS; }
            set { _TZSTATUS = value; }
        }
        int _DJSTATUS;

        public int DJSTATUS
        {
            get { return _DJSTATUS; }
            set { _DJSTATUS = value; }
        }
        string _DJNAME;

        public string DJNAME
        {
            get { return _DJNAME; }
            set { _DJNAME = value; }
        }
        int _DID;

        public int DID
        {
            get { return _DID; }
            set { _DID = value; }
        }
    }
}
