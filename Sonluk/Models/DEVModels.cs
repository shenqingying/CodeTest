using Sonluk.UI.Model.DEV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.Models
{
    public class DEVModels
    {
        private Log _Log;
        private Table _Table;

        public Log Log
        {
            get
            {
                if (_Log == null)
                    _Log = new Log();
                return _Log;
            }
            set { _Log = value; }
        }
        public Table Table
        {
            get
            {
                if (_Table == null)
                    _Table = new Table();
                return _Table;
            }
            set { _Table = value; }
        }
    }
}