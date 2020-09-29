using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sonluk.UI.Model.SD;

namespace Sonluk.Models
{
    public class SDModels
    {
        private SalesOrder _SalesOrder;

        public SalesOrder SalesOrder
        {
            get
            {
                if (_SalesOrder == null)
                    _SalesOrder = new SalesOrder();
                return _SalesOrder;
            }
            set { _SalesOrder = value; }
        }
    }
}