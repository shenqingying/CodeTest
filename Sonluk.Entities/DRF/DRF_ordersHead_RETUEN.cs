using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.DRF
{
    public class DRF_ordersHead_RETUEN
    {
        private bool _error;

        public bool error
        {
            get { return _error; }
            set { _error = value; }
        }
        private List<DRF_ordersHead_LIST> _data;

        public List<DRF_ordersHead_LIST> data
        {
            get { return _data; }
            set { _data = value; }
        }
        private string _msg;

        public string msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
        private int _status;

        public int status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
