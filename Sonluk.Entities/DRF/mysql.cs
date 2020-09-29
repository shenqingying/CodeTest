using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.DRF
{
    public class mysql
    {
        private string _columns;

        public string columns
        {
            get { return _columns; }
            set { _columns = value; }
        }
        private List<condition> _condition;

        public List<condition> condition
        {
            get { return _condition; }
            set { _condition = value; }
        }
        private orderby _orderby;

        public orderby orderby
        {
            get { return _orderby; }
            set { _orderby = value; }
        }
    }
}
