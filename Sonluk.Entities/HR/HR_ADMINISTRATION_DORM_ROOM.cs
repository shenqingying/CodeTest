using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_ADMINISTRATION_DORM_ROOM
    {
        private int _ROOMID;

        public int ROOMID
        {
            get { return _ROOMID; }
            set { _ROOMID = value; }
        }
        private int _DORMID;

        public int DORMID
        {
            get { return _DORMID; }
            set { _DORMID = value; }
        }
        private string _ROOMNAME;

        public string ROOMNAME
        {
            get { return _ROOMNAME; }
            set { _ROOMNAME = value; }
        }
        private int _ROOMTYPE;

        public int ROOMTYPE
        {
            get { return _ROOMTYPE; }
            set { _ROOMTYPE = value; }
        }
        private int _ROOMRYCOUNT;

        public int ROOMRYCOUNT
        {
            get { return _ROOMRYCOUNT; }
            set { _ROOMRYCOUNT = value; }
        }
        private string _REMARK;

        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        private int _CJR;

        public int CJR
        {
            get { return _CJR; }
            set { _CJR = value; }
        }
        private int _XGR;

        public int XGR
        {
            get { return _XGR; }
            set { _XGR = value; }
        }
        private int _ROOMZT;

        public int ROOMZT
        {
            get { return _ROOMZT; }
            set { _ROOMZT = value; }
        }
        private int _LIVECOUNT;

        public int LIVECOUNT
        {
            get { return _LIVECOUNT; }
            set { _LIVECOUNT = value; }
        }
        private int _LB;

        public int LB
        {
            get { return _LB; }
            set { _LB = value; }
        }
        private string _DORMNAME;

        public string DORMNAME
        {
            get { return _DORMNAME; }
            set { _DORMNAME = value; }
        }
        private string _LIVENAME;

        public string LIVENAME
        {
            get { return _LIVENAME; }
            set { _LIVENAME = value; }
        }
        private string _ROOMTYPELIST;

        public string ROOMTYPELIST
        {
            get { return _ROOMTYPELIST; }
            set { _ROOMTYPELIST = value; }
        }
    }
}
