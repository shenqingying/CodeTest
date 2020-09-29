using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_MANUALBB
    {
        private int _BBID;  //版本ID

        public int BBID
        {
            get { return _BBID; }
            set { _BBID = value; }
        }
        private string _BBNAME;  //版本号

        public string BBNAME
        {
            get { return _BBNAME; }
            set { _BBNAME = value; }
        }
        private int _MANUALID;  //说明书ID

        public int MANUALID
        {
            get { return _MANUALID; }
            set { _MANUALID = value; }
        }
        private string _JLTIME;  //创建时间

        public string JLTIME
        {
            get { return _JLTIME; }
            set { _JLTIME = value; }
        }
        private int _CJR;  //创建人

        public int CJR
        {
            get { return _CJR; }
            set { _CJR = value; }
        }
        private string _CJRNAME;  //创建人描述

        public string CJRNAME
        {
            get { return _CJRNAME; }
            set { _CJRNAME = value; }
        }
        private int _ISACTION;  //是否激活

        public int ISACTION
        {
            get { return _ISACTION; }
            set { _ISACTION = value; }
        }
        private int _ISDELETE;  //是否删除

        public int ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }
        private string _TM;  //说明书版本条码（说明书条码+版本号生成）

        public string TM
        {
            get { return _TM; }
            set { _TM = value; }
        }
        int _LANGU;

        public int LANGU
        {
            get { return _LANGU; }
            set { _LANGU = value; }
        }
        string _LANGUMS;

        public string LANGUMS
        {
            get { return _LANGUMS; }
            set { _LANGUMS = value; }
        }

    }
}
