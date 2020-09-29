using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MSG
{
    public class MSG_MSG_TYPE
    {
        int _MSGTYPEID;

        public int MSGTYPEID
        {
            get { return _MSGTYPEID; }
            set { _MSGTYPEID = value; }
        }
        string _TYPENAME;

        public string TYPENAME
        {
            get { return _TYPENAME; }
            set { _TYPENAME = value; }
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
        string _CJRNAME;

        public string CJRNAME
        {
            get { return _CJRNAME; }
            set { _CJRNAME = value; }
        }




    }
}
