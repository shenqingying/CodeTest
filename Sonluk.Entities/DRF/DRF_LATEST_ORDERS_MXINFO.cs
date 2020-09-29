using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.DRF
{
    public class DRF_LATEST_ORDERS_MXINFO
    {
        private string _account;

        public string Account
        {
            get { return _account; }
            set { _account = value; }
        }
        private string _ordernum;

        public string Ordernum
        {
            get { return _ordernum; }
            set { _ordernum = value; }
        }
        private string _storenum;

        public string Storenum
        {
            get { return _storenum; }
            set { _storenum = value; }
        }
        private int _status;

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
