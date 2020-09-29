using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sonluk.UI.Model.CRM.ORDER_TTService;

namespace Sonluk.PC.Models
{
    public class PrintOrder
    {
        CRM_ORDER_TT _TTdata;

        public CRM_ORDER_TT TTdata
        {
            get { return _TTdata; }
            set { _TTdata = value; }
        }
        CRM_ORDER_MX[] _MXdata;

        public CRM_ORDER_MX[] MXdata
        {
            get { return _MXdata; }
            set { _MXdata = value; }
        }



    }
}