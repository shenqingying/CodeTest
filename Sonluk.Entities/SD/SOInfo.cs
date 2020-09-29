using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.SD
{
    public class SOInfo
    {
        private SOHeaderInfo _Header;
        private List<SOItemInfo> _Items;
        private int _Status;

        public SOHeaderInfo Header
        {
            get { return _Header; }
            set { _Header = value; }
        }
        public List<SOItemInfo> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
    }
}
