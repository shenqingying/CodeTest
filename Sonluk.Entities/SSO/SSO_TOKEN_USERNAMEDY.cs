using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.SSO
{
    public class SSO_TOKEN_USERNAMEDY
    {
        private int _ZHID;

        public int ZHID
        {
            get { return _ZHID; }
            set { _ZHID = value; }
        }
        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        private int _ZHLB;

        public int ZHLB
        {
            get { return _ZHLB; }
            set { _ZHLB = value; }
        }
        private string _ZHUSERNAME;

        public string ZHUSERNAME
        {
            get { return _ZHUSERNAME; }
            set { _ZHUSERNAME = value; }
        }
        private int _UPDATELB;

        public int UPDATELB
        {
            get { return _UPDATELB; }
            set { _UPDATELB = value; }
        }
        private int _ZHUSERID;

        public int ZHUSERID
        {
            get { return _ZHUSERID; }
            set { _ZHUSERID = value; }
        }
    }
}
