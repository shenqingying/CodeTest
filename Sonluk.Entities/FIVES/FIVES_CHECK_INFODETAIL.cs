using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_CHECK_INFODETAIL
    {
        private int _DETAILID;  //检查明细ID

        public int DETAILID
        {
            get { return _DETAILID; }
            set { _DETAILID = value; }
        }
        private int _INFOID;  //检查抬头ID

        public int INFOID
        {
            get { return _INFOID; }
            set { _INFOID = value; }
        }
        private int _TYPEID;  //检查明细类型ID

        public int TYPEID
        {
            get { return _TYPEID; }
            set { _TYPEID = value; }
        }
        private string _TYPEMS;  //检查明细描述

        public string TYPEMS
        {
            get { return _TYPEMS; }
            set { _TYPEMS = value; }
        }
        private int _SCROEID;  //明细结果

        public int SCROEID
        {
            get { return _SCROEID; }
            set { _SCROEID = value; }
        }
        private string _SCROEMS;  //明细结果描述

        public string SCROEMS
        {
            get { return _SCROEMS; }
            set { _SCROEMS = value; }
        }
        private string _JLTIME;  //记录时间

        public string JLTIME
        {
            get { return _JLTIME; }
            set { _JLTIME = value; }
        }
        private string _REMARK;  //备注

        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        private int _ACTION;  //状态

        public int ACTION
        {
            get { return _ACTION; }
            set { _ACTION = value; }
        }
        private bool _ISDELETE;  //是否删除

        public bool ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }

    }
}
