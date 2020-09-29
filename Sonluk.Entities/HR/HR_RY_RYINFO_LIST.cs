using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_RY_RYINFO_LIST
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
        private string _YGNAME;

        public string YGNAME
        {
            get { return _YGNAME; }
            set { _YGNAME = value; }
        }
        private int _DEPT;

        public int DEPT
        {
            get { return _DEPT; }
            set { _DEPT = value; }
        }
        private string _DEPTNAME;

        public string DEPTNAME
        {
            get { return _DEPTNAME; }
            set { _DEPTNAME = value; }
        }
        private int _GSBM;

        public int GSBM
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
        private int _ZZZT;

        public int ZZZT
        {
            get { return _ZZZT; }
            set { _ZZZT = value; }
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
        private string _GSNAME;

        public string GSNAME
        {
            get { return _GSNAME; }
            set { _GSNAME = value; }
        }
        private string _DUTYLEVEL;

        public string DUTYLEVEL
        {
            get { return _DUTYLEVEL; }
            set { _DUTYLEVEL = value; }
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
        private string _GSBMGSNAME;

        public string GSBMGSNAME
        {
            get { return _GSBMGSNAME; }
            set { _GSBMGSNAME = value; }
        }
        private string _ZCNAME;

        public string ZCNAME
        {
            get { return _ZCNAME; }
            set { _ZCNAME = value; }
        }
        private int _HTID;

        public int HTID
        {
            get { return _HTID; }
            set { _HTID = value; }
        }private int _HTZT;

        public int HTZT
        {
            get { return _HTZT; }
            set { _HTZT = value; }
        }
        private string _HTZTNAME;

        public string HTZTNAME
        {
            get { return _HTZTNAME; }
            set { _HTZTNAME = value; }
        }
        private int _HTQXLB;

        public int HTQXLB
        {
            get { return _HTQXLB; }
            set { _HTQXLB = value; }
        }
        private string _HTQXLBNAME;

        public string HTQXLBNAME
        {
            get { return _HTQXLBNAME; }
            set { _HTQXLBNAME = value; }
        }
        private string _HTQX;

        public string HTQX
        {
            get { return _HTQX; }
            set { _HTQX = value; }
        }
        private int _HTQCS;

        public int HTQCS
        {
            get { return _HTQCS; }
            set { _HTQCS = value; }
        }
        private string _SYDATE;

        public string SYDATE
        {
            get { return _SYDATE; }
            set { _SYDATE = value; }
        }
        private string _QDRQ;

        public string QDRQ
        {
            get { return _QDRQ; }
            set { _QDRQ = value; }
        }
        private string _SXRQ;

        public string SXRQ
        {
            get { return _SXRQ; }
            set { _SXRQ = value; }
        }
        private string _DQR;

        public string DQR
        {
            get { return _DQR; }
            set { _DQR = value; }
        }
        private string _HTREMARK;

        public string HTREMARK
        {
            get { return _HTREMARK; }
            set { _HTREMARK = value; }
        }
        private int _GSID;

        public int GSID
        {
            get { return _GSID; }
            set { _GSID = value; }
        }
        private string _GSDATE;

        public string GSDATE
        {
            get { return _GSDATE; }
            set { _GSDATE = value; }
        }
        private int _GSLEVEL;

        public int GSLEVEL
        {
            get { return _GSLEVEL; }
            set { _GSLEVEL = value; }
        }
        private string _GSLEVELNAME;

        public string GSLEVELNAME
        {
            get { return _GSLEVELNAME; }
            set { _GSLEVELNAME = value; }
        }
        private string _YLKSDATE;

        public string YLKSDATE
        {
            get { return _YLKSDATE; }
            set { _YLKSDATE = value; }
        }
        private string _YLJSDATE;

        public string YLJSDATE
        {
            get { return _YLJSDATE; }
            set { _YLJSDATE = value; }
        }
        private string _GSREMARK;

        public string GSREMARK
        {
            get { return _GSREMARK; }
            set { _GSREMARK = value; }
        }
        private int _WJID;

        public int WJID
        {
            get { return _WJID; }
            set { _WJID = value; }
        }
        private string _FSDATE;

        public string FSDATE
        {
            get { return _FSDATE; }
            set { _FSDATE = value; }
        }
        private string _SM;

        public string SM
        {
            get { return _SM; }
            set { _SM = value; }
        }
        private int _WBZWID;

        public int WBZWID
        {
            get { return _WBZWID; }
            set { _WBZWID = value; }
        }
        private string _WBZWNAME;

        public string WBZWNAME
        {
            get { return _WBZWNAME; }
            set { _WBZWNAME = value; }
        }
        private string _WBZWDW;

        public string WBZWDW
        {
            get { return _WBZWDW; }
            set { _WBZWDW = value; }
        }
        private string _WBPYRQ;

        public string WBPYRQ
        {
            get { return _WBPYRQ; }
            set { _WBPYRQ = value; }
        }
        private string _WBJZRQ;

        public string WBJZRQ
        {
            get { return _WBJZRQ; }
            set { _WBJZRQ = value; }
        }
        private string _WBZWREMARK;

        public string WBZWREMARK
        {
            get { return _WBZWREMARK; }
            set { _WBZWREMARK = value; }
        }
        private int _BZ;

        public int BZ
        {
            get { return _BZ; }
            set { _BZ = value; }
        }
        private string _BZNAME;

        public string BZNAME
        {
            get { return _BZNAME; }
            set { _BZNAME = value; }
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
        private string _ZWLEVELNAME;

        public string ZWLEVELNAME
        {
            get { return _ZWLEVELNAME; }
            set { _ZWLEVELNAME = value; }
        }
        private string _GSJC;

        public string GSJC
        {
            get { return _GSJC; }
            set { _GSJC = value; }
        }
        string _IMAGEFILE;

        public string IMAGEFILE
        {
            get { return _IMAGEFILE; }
            set { _IMAGEFILE = value; }
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
        private string _FPDATE;

        public string FPDATE
        {
            get { return _FPDATE; }
            set { _FPDATE = value; }
        }
    }
}
