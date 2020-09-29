using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_ORDER_DRF_USER_SELECT
    {
        private List<CRM_ORDER_DRF_USER> _CRM_ORDER_DRF_USER;

        public List<CRM_ORDER_DRF_USER> CRM_ORDER_DRF_USER
        {
            get { return _CRM_ORDER_DRF_USER; }
            set { _CRM_ORDER_DRF_USER = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
