using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_RELATIONSHIPBINDList
    {
        private int _OBJ1;  //对象1

        public int OBJ1
        {
            get { return _OBJ1; }
            set { _OBJ1 = value; }
        }
        private int _OBJ2;  //对象2

        public int OBJ2
        {
            get { return _OBJ2; }
            set { _OBJ2 = value; }
        }
        private int _TYPE;  //关联类型

        public int TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
        }
        private int _ACTION;  //激活状态

        public int ACTION
        {
            get { return _ACTION; }
            set { _ACTION = value; }
        }
        string _OBJ1NAME;

        public string OBJ1NAME
        {
            get { return _OBJ1NAME; }
            set { _OBJ1NAME = value; }
        }
        string _OBJ2NAME;

        public string OBJ2NAME
        {
            get { return _OBJ2NAME; }
            set { _OBJ2NAME = value; }
        }
        string _TYPENAME;

        public string TYPENAME
        {
            get { return _TYPENAME; }
            set { _TYPENAME = value; }
        }
        string _TYPEREMARK;

        public string TYPEREMARK
        {
            get { return _TYPEREMARK; }
            set { _TYPEREMARK = value; }
        }

        string _dp;

        public string Dp
        {
            get { return _dp; }
            set { _dp = value; }
        }
        string _REMARK;

        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
    }
}
