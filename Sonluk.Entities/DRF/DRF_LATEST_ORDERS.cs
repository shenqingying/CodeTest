using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.DRF
{
    public class DRF_LATEST_ORDERS
    {
        private DataSet _orders;

        public DataSet Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }
        private DataSet _ordersDone;

        public DataSet OrdersDone
        {
            get { return _ordersDone; }
            set { _ordersDone = value; }
        }
    }
}
