using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_RY_RYINFO
    {
        private int _RYID;

        public int RYID
        {
            get { return _RYID; }
            set { _RYID = value; }
        }
        private string _GS;

        public string GS
        {
            get { return _GS; }
            set { _GS = value; }
        }
        private string _ALLGS;

        public string ALLGS
        {
            get { return _ALLGS; }
            set { _ALLGS = value; }
        }
        private string _YGNAME;

        public string YGNAME
        {
            get { return _YGNAME; }
            set { _YGNAME = value; }
        }
        private string _DEPT;

        public string DEPT
        {
            get { return _DEPT; }
            set { _DEPT = value; }
        }
        private string _stringDEPT;

        public string stringDEPT
        {
            get { return _stringDEPT; }
            set { _stringDEPT = value; }
        }
        private string _DEPTNAME;

        public string DEPTNAME
        {
            get { return _DEPTNAME; }
            set { _DEPTNAME = value; }
        }
        private string _GSBM;

        public string GSBM
        {
            get { return _GSBM; }
            set { _GSBM = value; }
        }
        private string _GSBMNAME;

        public string GSBMNAME
        {
            get { return _GSBMNAME; }
            set { _GSBMNAME = value; }
        }
        private string _ZZZT;

        public string ZZZT
        {
            get { return _ZZZT; }
            set { _ZZZT = value; }
        }
        private string _stringZZZT;

        public string stringZZZT
        {
            get { return _stringZZZT; }
            set { _stringZZZT = value; }
        }
        private string _ZZZTNAME;

        public string ZZZTNAME
        {
            get { return _ZZZTNAME; }
            set { _ZZZTNAME = value; }
        }
        private string _RZDATE;

        public string RZDATE
        {
            get { return _RZDATE; }
            set { _RZDATE = value; }
        }
        private string _LZRQ;

        public string LZRQ
        {
            get { return _LZRQ; }
            set { _LZRQ = value; }
        }
        private string _GH;

        public string GH
        {
            get { return _GH; }
            set { _GH = value; }
        }
        private int _ZZTYPE;

        public int ZZTYPE
        {
            get { return _ZZTYPE; }
            set { _ZZTYPE = value; }
        }
        private string _ZZTYPENAME;

        public string ZZTYPENAME
        {
            get { return _ZZTYPENAME; }
            set { _ZZTYPENAME = value; }
        }
        private string _ZZNO;

        public string ZZNO
        {
            get { return _ZZNO; }
            set { _ZZNO = value; }
        }
        private string _BIRTHDAT;

        public string BIRTHDAT
        {
            get { return _BIRTHDAT; }
            set { _BIRTHDAT = value; }
        }
        private string _XB;

        public string XB
        {
            get { return _XB; }
            set { _XB = value; }
        }
        private string _SFZYXRQ;

        public string SFZYXRQ
        {
            get { return _SFZYXRQ; }
            set { _SFZYXRQ = value; }
        }
        private int _YGXZ;

        public int YGXZ
        {
            get { return _YGXZ; }
            set { _YGXZ = value; }
        }
        private string _YGXZNAME;

        public string YGXZNAME
        {
            get { return _YGXZNAME; }
            set { _YGXZNAME = value; }
        }
        private int _YGTYPE;

        public int YGTYPE
        {
            get { return _YGTYPE; }
            set { _YGTYPE = value; }
        }
        private string _YGTYPENAME;

        public string YGTYPENAME
        {
            get { return _YGTYPENAME; }
            set { _YGTYPENAME = value; }
        }
        private string _GLQSR;

        public string GLQSR
        {
            get { return _GLQSR; }
            set { _GLQSR = value; }
        }
        private string _GHOLD;

        public string GHOLD
        {
            get { return _GHOLD; }
            set { _GHOLD = value; }
        }
        private string _DUTYNAME;

        public string DUTYNAME
        {
            get { return _DUTYNAME; }
            set { _DUTYNAME = value; }
        }
        private int _JOBS;

        public int JOBS
        {
            get { return _JOBS; }
            set { _JOBS = value; }
        }
        private string _JOBSNAME;

        public string JOBSNAME
        {
            get { return _JOBSNAME; }
            set { _JOBSNAME = value; }
        }
        private int _GJ;

        public int GJ
        {
            get { return _GJ; }
            set { _GJ = value; }
        }
        private string _GJNAME;

        public string GJNAME
        {
            get { return _GJNAME; }
            set { _GJNAME = value; }
        }
        private int _PX;

        public int PX
        {
            get { return _PX; }
            set { _PX = value; }
        }
        private int _HYZK;

        public int HYZK
        {
            get { return _HYZK; }
            set { _HYZK = value; }
        }
        private string _HYZKNAME;

        public string HYZKNAME
        {
            get { return _HYZKNAME; }
            set { _HYZKNAME = value; }
        }
        private int _ZZMM;

        public int ZZMM
        {
            get { return _ZZMM; }
            set { _ZZMM = value; }
        }
        private string _ZZMMNAME;

        public string ZZMMNAME
        {
            get { return _ZZMMNAME; }
            set { _ZZMMNAME = value; }
        }
        private string _HJADDRESS;

        public string HJADDRESS
        {
            get { return _HJADDRESS; }
            set { _HJADDRESS = value; }
        }
        private string _JZADDRESS;

        public string JZADDRESS
        {
            get { return _JZADDRESS; }
            set { _JZADDRESS = value; }
        }
        private string _PHONENUMBER;

        public string PHONENUMBER
        {
            get { return _PHONENUMBER; }
            set { _PHONENUMBER = value; }
        }
        private string _EMAIL;

        public string EMAIL
        {
            get { return _EMAIL; }
            set { _EMAIL = value; }
        }
        private string _JG;

        public string JG
        {
            get { return _JG; }
            set { _JG = value; }
        }
        private int _MZ;

        public int MZ
        {
            get { return _MZ; }
            set { _MZ = value; }
        }
        private string _MZNAME;

        public string MZNAME
        {
            get { return _MZNAME; }
            set { _MZNAME = value; }
        }
        private string _NSRSBH;

        public string NSRSBH
        {
            get { return _NSRSBH; }
            set { _NSRSBH = value; }
        }
        private int _NSRSF;

        public int NSRSF
        {
            get { return _NSRSF; }
            set { _NSRSF = value; }
        }
        private string _NSRSFNAME;

        public string NSRSFNAME
        {
            get { return _NSRSFNAME; }
            set { _NSRSFNAME = value; }
        }
        private string _ZY;

        public string ZY
        {
            get { return _ZY; }
            set { _ZY = value; }
        }
        private string _REMARK;

        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        private int _ISINGH;

        public int ISINGH
        {
            get { return _ISINGH; }
            set { _ISINGH = value; }
        }
        private string _GHDATE;

        public string GHDATE
        {
            get { return _GHDATE; }
            set { _GHDATE = value; }
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
        private string _RZRQKS;

        public string RZRQKS
        {
            get { return _RZRQKS; }
            set { _RZRQKS = value; }
        }
        private string _RZRQJS;

        public string RZRQJS
        {
            get { return _RZRQJS; }
            set { _RZRQJS = value; }
        }
        private int _STUDEFS;

        public int STUDEFS
        {
            get { return _STUDEFS; }
            set { _STUDEFS = value; }
        }
        private string _STUDEFSNAME;

        public string STUDEFSNAME
        {
            get { return _STUDEFSNAME; }
            set { _STUDEFSNAME = value; }
        }
        private int _EDUCACTION;

        public int EDUCACTION
        {
            get { return _EDUCACTION; }
            set { _EDUCACTION = value; }
        }
        private string _EDUCACTIONNAME;

        public string EDUCACTIONNAME
        {
            get { return _EDUCACTIONNAME; }
            set { _EDUCACTIONNAME = value; }
        }
        private string _NOSELECT;

        public string NOSELECT
        {
            get { return _NOSELECT; }
            set { _NOSELECT = value; }
        }
        private string _IMAGEURL;

        public string IMAGEURL
        {
            get { return _IMAGEURL; }
            set { _IMAGEURL = value; }
        }
        private int _ISCJ;

        public int ISCJ
        {
            get { return _ISCJ; }
            set { _ISCJ = value; }
        }
        private string _CJNO;

        public string CJNO
        {
            get { return _CJNO; }
            set { _CJNO = value; }
        }
        private int _ISLS;

        public int ISLS
        {
            get { return _ISLS; }
            set { _ISLS = value; }
        }
        private string _LSNO;

        public string LSNO
        {
            get { return _LSNO; }
            set { _LSNO = value; }
        }
        private int _ISGL;

        public int ISGL
        {
            get { return _ISGL; }
            set { _ISGL = value; }
        }
        private int _ISJZZ;

        public int ISJZZ
        {
            get { return _ISJZZ; }
            set { _ISJZZ = value; }
        }
        private string _JZZYYQ;

        public string JZZYYQ
        {
            get { return _JZZYYQ; }
            set { _JZZYYQ = value; }
        }
        private int _ISHY;

        public int ISHY
        {
            get { return _ISHY; }
            set { _ISHY = value; }
        }
        private string _HYNO;

        public string HYNO
        {
            get { return _HYNO; }
            set { _HYNO = value; }
        }
        private string _HYYYQ;

        public string HYYYQ
        {
            get { return _HYYYQ; }
            set { _HYYYQ = value; }
        }
        private string _YGLB;

        public string YGLB
        {
            get { return _YGLB; }
            set { _YGLB = value; }
        }
        private string _JZDATE;

        public string JZDATE
        {
            get { return _JZDATE; }
            set { _JZDATE = value; }
        }
        private string _HTSXRQKS;

        public string HTSXRQKS
        {
            get { return _HTSXRQKS; }
            set { _HTSXRQKS = value; }
        }
        private string _HTSXRQJS;

        public string HTSXRQJS
        {
            get { return _HTSXRQJS; }
            set { _HTSXRQJS = value; }
        }
        private string _LZRQKS;

        public string LZRQKS
        {
            get { return _LZRQKS; }
            set { _LZRQKS = value; }
        }
        private string _LZRQJS;

        public string LZRQJS
        {
            get { return _LZRQJS; }
            set { _LZRQJS = value; }
        }
        private string _ALLRYID;

        public string ALLRYID
        {
            get { return _ALLRYID; }
            set { _ALLRYID = value; }
        }
        private string _GHDATEKS;

        public string GHDATEKS
        {
            get { return _GHDATEKS; }
            set { _GHDATEKS = value; }
        }
        private string _GHDATEJS;

        public string GHDATEJS
        {
            get { return _GHDATEJS; }
            set { _GHDATEJS = value; }
        }
        private string _ISINGHSTRING;

        public string ISINGHSTRING
        {
            get { return _ISINGHSTRING; }
            set { _ISINGHSTRING = value; }
        }
        private string _BIRTHDAYKS;

        public string BIRTHDAYKS
        {
            get { return _BIRTHDAYKS; }
            set { _BIRTHDAYKS = value; }
        }
        private string _BIRTHDAYJS;

        public string BIRTHDAYJS
        {
            get { return _BIRTHDAYJS; }
            set { _BIRTHDAYJS = value; }
        }
        private int _BZ;

        public int BZ
        {
            get { return _BZ; }
            set { _BZ = value; }
        }
        private string _DATEKS;

        public string DATEKS
        {
            get { return _DATEKS; }
            set { _DATEKS = value; }
        }
        private string _DATEJS;

        public string DATEJS
        {
            get { return _DATEJS; }
            set { _DATEJS = value; }
        }
        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        private int _ISECRZ;

        public int ISECRZ
        {
            get { return _ISECRZ; }
            set { _ISECRZ = value; }
        }
        private int _ZWLEVEL;

        public int ZWLEVEL
        {
            get { return _ZWLEVEL; }
            set { _ZWLEVEL = value; }
        }
        private string _ZWLEVELLIST;

        public string ZWLEVELLIST
        {
            get { return _ZWLEVELLIST; }
            set { _ZWLEVELLIST = value; }
        }
        private int _LB;

        public int LB
        {
            get { return _LB; }
            set { _LB = value; }
        }
        private string _EDUCACTIONSCHOOL;

        public string EDUCACTIONSCHOOL
        {
            get { return _EDUCACTIONSCHOOL; }
            set { _EDUCACTIONSCHOOL = value; }
        }
        private string _PHONESHORT;

        public string PHONESHORT
        {
            get { return _PHONESHORT; }
            set { _PHONESHORT = value; }
        }
        private DataTable _RYINFOLIST;

        public DataTable RYINFOLIST
        {
            get { return _RYINFOLIST; }
            set { _RYINFOLIST = value; }
        }
        private string _FPDATE;

        public string FPDATE
        {
            get { return _FPDATE; }
            set { _FPDATE = value; }
        }
    }
}