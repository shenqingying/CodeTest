using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_DRF_RETURNMSG
    {
        private bool _error;

        public bool Error
        {
            get { return _error; }
            set { _error = value; }
        }
        private int _data;

        public int Data
        {
            get { return _data; }
            set { _data = value; }
        }
        private string _msg;

        public string Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
        private int _status;

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
