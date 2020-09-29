using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_CHECKPOINT_CHECKDETAILLIST
    {
        private int _POINTID;  //检查点ID

        public int POINTID
        {
            get { return _POINTID; }
            set { _POINTID = value; }
        }
        private int _DETAILID;  //检查明细ID

        public int DETAILID
        {
            get { return _DETAILID; }
            set { _DETAILID = value; }
        }
        string _PNAME;

        public string PNAME
        {
            get { return _PNAME; }
            set { _PNAME = value; }
        }
        string _LNAME;

        public string LNAME
        {
            get { return _LNAME; }
            set { _LNAME = value; }
        }
        string _DNAME;

        public string DNAME
        {
            get { return _DNAME; }
            set { _DNAME = value; }
        }
    }
}
