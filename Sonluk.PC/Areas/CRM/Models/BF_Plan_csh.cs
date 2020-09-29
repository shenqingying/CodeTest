using Sonluk.UI.Model.CRM.HG_DEPTService;
using Sonluk.UI.Model.CRM.HG_DICTService;
using Sonluk.UI.Model.CRM.HG_STAFFService;
using Sonluk.UI.Model.CRM.KH_GROUPService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Areas.CRM.Models
{
    public class BF_Plan_csh
    {
        private CRM_KH_GROUP[] _KH_GROUP;

        public CRM_KH_GROUP[] KH_GROUP
        {
            get { return _KH_GROUP; }
            set { _KH_GROUP = value; }
        }

        private CRM_HG_DICT[] _BFJH;

        public CRM_HG_DICT[] BFJH
        {
            get { return _BFJH; }
            set { _BFJH = value; }
        }

        private CRM_HG_DEPT[] _DEPT;

        public CRM_HG_DEPT[] DEPT
        {
            get { return _DEPT; }
            set { _DEPT = value; }
        }

        private CRM_HG_STAFFList[] _STAFF;

        public CRM_HG_STAFFList[] STAFF
        {
            get { return _STAFF; }
            set { _STAFF = value; }
        }

    }
}