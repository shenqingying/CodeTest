using Sonluk.UI.Model.CRM.COST_CLFMXService;
using Sonluk.UI.Model.CRM.COST_CLFTTService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models
{
    public class PrintClf
    {
        CRM_COST_CLFTT _TTdata;

        public CRM_COST_CLFTT TTdata
        {
            get { return _TTdata; }
            set { _TTdata = value; }
        }
        CRM_COST_CLFMX[] _MXdata;

        public CRM_COST_CLFMX[] MXdata
        {
            get { return _MXdata; }
            set { _MXdata = value; }
        }
    }
}