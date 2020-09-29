using Sonluk.UI.Model.HR.RY_RYINFOService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Areas.HR.Models
{
    public class MODEL_RYINFO_PRINTF
    {
        private HR_RY_RYINFO_LIST _HR_RY_RYINFO_LIST;

        public HR_RY_RYINFO_LIST HR_RY_RYINFO_LIST
        {
            get { return _HR_RY_RYINFO_LIST; }
            set { _HR_RY_RYINFO_LIST = value; }
        }
        private string _LZYY;

        public string LZYY
        {
            get { return _LZYY; }
            set { _LZYY = value; }
        }
    }
}