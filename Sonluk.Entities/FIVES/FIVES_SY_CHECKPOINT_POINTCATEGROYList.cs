using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_CHECKPOINT_POINTCATEGROYList
    {
        private int _POINTID;  //检查点ID

        public int POINTID
        {
            get { return _POINTID; }
            set { _POINTID = value; }
        }
        private int _CATEGROYID;  //检查点分类ID

        public int CATEGROYID
        {
            get { return _CATEGROYID; }
            set { _CATEGROYID = value; }
        }
        string _PNAME;

        public string PNAME
        {
            get { return _PNAME; }
            set { _PNAME = value; }
        }
        string _CNAME;

        public string CNAME
        {
            get { return _CNAME; }
            set { _CNAME = value; }
        }
        string _LNAME;

        public string LNAME
        {
            get { return _LNAME; }
            set { _LNAME = value; }
        }
    }
}
