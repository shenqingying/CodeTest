using Sonluk.UI.Model.BC;
using Sonluk.UI.Model.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.Models
{
    public class LEModels
    {
        private OutboundDelivery _OutboundDelivery;

        public OutboundDelivery OutboundDelivery
        {
            get
            {
                if (_OutboundDelivery == null)
                    _OutboundDelivery = new OutboundDelivery();
                return _OutboundDelivery;
            }
            set { _OutboundDelivery = value; }
        }
    }
}