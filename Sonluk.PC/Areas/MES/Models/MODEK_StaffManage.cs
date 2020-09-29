using Sonluk.UI.Model.CRM.HG_DEPTService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Areas.MES.Models
{
    public class MODEK_StaffManage
    {
        private CRM_HG_DEPT[] _CRM_HG_DEPT;

        public CRM_HG_DEPT[] CRM_HG_DEPT
        {
            get { return _CRM_HG_DEPT; }
            set { _CRM_HG_DEPT = value; }
        }
    }
}