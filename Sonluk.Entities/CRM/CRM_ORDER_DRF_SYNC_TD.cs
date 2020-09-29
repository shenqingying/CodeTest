using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_ORDER_DRF_SYNC_TD
    {
        private string _ACCOUNT;

        public string ACCOUNT
        {
            get { return _ACCOUNT; }
            set { _ACCOUNT = value; }
        }
        private string _ORDERNUM;

        public string ORDERNUM
        {
            get { return _ORDERNUM; }
            set { _ORDERNUM = value; }
        }
        private string _STORENUM;

        public string STORENUM
        {
            get { return _STORENUM; }
            set { _STORENUM = value; }
        }
        private string _LBNAME;

        public string LBNAME
        {
            get { return _LBNAME; }
            set { _LBNAME = value; }
        }
        private string _TD;

        public string TD
        {
            get { return _TD; }
            set { _TD = value; }
        }
    }
}
