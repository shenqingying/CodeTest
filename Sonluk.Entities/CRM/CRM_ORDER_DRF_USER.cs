using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_ORDER_DRF_USER
    {
        private int _USERACCOUNT;

        public int USERACCOUNT
        {
            get { return _USERACCOUNT; }
            set { _USERACCOUNT = value; }
        }
        private string _USERNAME;

        public string USERNAME
        {
            get { return _USERNAME; }
            set { _USERNAME = value; }
        }
        private string _REMARK;

        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
        private int _LB;

        public int LB
        {
            get { return _LB; }
            set { _LB = value; }
        }
    }
}
