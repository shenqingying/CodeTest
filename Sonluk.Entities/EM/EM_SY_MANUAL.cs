using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_MANUAL
    {
        private int _MANUALID;  //说明书ID

        public int MANUALID
        {
            get { return _MANUALID; }
            set { _MANUALID = value; }
        }
        private string _GC;  //工厂

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }
        private string _TM;  //说明书条码（包装作业指导书放物料号）

        public string TM
        {
            get { return _TM; }
            set { _TM = value; }
        }
        private int _TYPE;  //说明书类别ID

        public int TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
        }
        private string _TYPENAME;  //说明书类别描述

        public string TYPENAME
        {
            get { return _TYPENAME; }
            set { _TYPENAME = value; }
        }
        private string _REMARK;  //备注

        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
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
        private int _ISDELETE;  //是否删除

        public int ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }
        private string _MANUALMS; //描述

        public string MANUALMS
        {
            get { return _MANUALMS; }
            set { _MANUALMS = value; }
        }
        string _JLTIME;

        public string JLTIME
        {
            get { return _JLTIME; }
            set { _JLTIME = value; }
        }
        string _BBNAME;

        public string BBNAME
        {
            get { return _BBNAME; }
            set { _BBNAME = value; }
        }
    }
}
