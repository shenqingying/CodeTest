using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_DICT
    {
        private int _DICID;  //字典ID

        public int DICID
        {
            get { return _DICID; }
            set { _DICID = value; }
        }
        private int _TYPEID;  //类别ID

        public int TYPEID
        {
            get { return _TYPEID; }
            set { _TYPEID = value; }
        }
        private string _DICNAME;  //字典名称

        public string DICNAME
        {
            get { return _DICNAME; }
            set { _DICNAME = value; }
        }
        private string _DICMEMO;  //备注

        public string DICMEMO
        {
            get { return _DICMEMO; }
            set { _DICMEMO = value; }
        }
        private int _ACTION;  //是否激活

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
