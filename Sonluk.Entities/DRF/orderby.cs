using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.DRF
{
    public class orderby
    {
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private bool _desc;

        public bool desc
        {
            get { return _desc; }
            set { _desc = value; }
        }
    }
}
