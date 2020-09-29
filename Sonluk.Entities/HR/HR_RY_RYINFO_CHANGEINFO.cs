using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_RY_RYINFO_CHANGEINFO
    {
        private int _CHANGEID;

        public int CHANGEID
        {
            get { return _CHANGEID; }
            set { _CHANGEID = value; }
        }

        private int _RYID;

        public int RYID
        {
            get { return _RYID; }
            set { _RYID = value; }
        }
        private string _CHANGERQ;

        public string CHANGERQ
        {
            get { return _CHANGERQ; }
            set { _CHANGERQ = value; }
        }
        private int _CHANGELB;

        public int CHANGELB
        {
            get { return _CHANGELB; }
            set { _CHANGELB = value; }
        }
        private int _OLD;

        public int OLD
        {
            get { return _OLD; }
            set { _OLD = value; }
        }
        private string _OLDNAME;

        public string OLDNAME
        {
            get { return _OLDNAME; }
            set { _OLDNAME = value; }
        }
        private int _NEW;

        public int NEW
        {
            get { return _NEW; }
            set { _NEW = value; }
        }
        private string _NEWNAME;

        public string NEWNAME
        {
            get { return _NEWNAME; }
            set { _NEWNAME = value; }
        }
        private int _CHANGGEYY;

        public int CHANGGEYY
        {
            get { return _CHANGGEYY; }
            set { _CHANGGEYY = value; }
        }
        private string _CHANGGEYYNAME;

        public string CHANGGEYYNAME
        {
            get { return _CHANGGEYYNAME; }
            set { _CHANGGEYYNAME = value; }
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
    }
}
