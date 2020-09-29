using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_TYPE
    {
        private int _TYPEID;  //类别ID

        public int TYPEID
        {
            get { return _TYPEID; }
            set { _TYPEID = value; }
        }
        private string _TYPENAME;  //类别名称

        public string TYPENAME
        {
            get { return _TYPENAME; }
            set { _TYPENAME = value; }
        }
        private string _TYPEMEMO;  //备注

        public string TYPEMEMO
        {
            get { return _TYPEMEMO; }
            set { _TYPEMEMO = value; }
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
