using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_PRODUCT_GROUP
    {
        int _GROUPID;

        public int GROUPID
        {
            get { return _GROUPID; }
            set { _GROUPID = value; }
        }
        string _GROUPNAME;

        public string GROUPNAME
        {
            get { return _GROUPNAME; }
            set { _GROUPNAME = value; }
        }
        string _GROUPDES;

        public string GROUPDES
        {
            get { return _GROUPDES; }
            set { _GROUPDES = value; }
        }
        string _BEIZ;

        public string BEIZ
        {
            get { return _BEIZ; }
            set { _BEIZ = value; }
        }
        int _ISACTIVE;

        public int ISACTIVE
        {
            get { return _ISACTIVE; }
            set { _ISACTIVE = value; }
        }
        int _CJR;

        public int CJR
        {
            get { return _CJR; }
            set { _CJR = value; }
        }
        string _CJSJ;

        public string CJSJ
        {
            get { return _CJSJ; }
            set { _CJSJ = value; }
        }
        int _PRODUCTIDCOUNT;

        public int PRODUCTIDCOUNT
        {
            get { return _PRODUCTIDCOUNT; }
            set { _PRODUCTIDCOUNT = value; }
        }



    }
}
