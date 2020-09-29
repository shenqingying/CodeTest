using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.DRF
{
    public class condition
    {
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _op;

        public string op
        {
            get { return _op; }
            set { _op = value; }
        }
        private string _value;

        public string value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
