using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
 
    public class SAP_SOInfo
    {
        private SAP_SOHeaderInfo _Header;
        private List<SAP_SOItemInfo> _Items;
        private int _Status;

        public SAP_SOHeaderInfo Header
        {
            get { return _Header; }
            set { _Header = value; }
        }
        public List<SAP_SOItemInfo> Items
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
