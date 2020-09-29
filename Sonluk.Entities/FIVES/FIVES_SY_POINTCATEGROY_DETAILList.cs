using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.FIVES
{
    public class FIVES_SY_POINTCATEGROY_DETAILList
    {
        private int _CATEGROYID;  //检查点分类ID

        public int CATEGROYID
        {
            get { return _CATEGROYID; }
            set { _CATEGROYID = value; }
        }
        private int _DETAILID;  //检查明细ID

        public int DETAILID
        {
            get { return _DETAILID; }
            set { _DETAILID = value; }
        }
        string _CNAME;

        public string CNAME
        {
            get { return _CNAME; }
            set { _CNAME = value; }
        }
        string _DNAME;

        public string DNAME
        {
            get { return _DNAME; }
            set { _DNAME = value; }
        }
    }
}
