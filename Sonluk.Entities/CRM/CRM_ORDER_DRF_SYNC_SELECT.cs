using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_ORDER_DRF_SYNC_SELECT
    {
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        private List<CRM_ORDER_DRF_SYNC> _CRM_ORDER_DRF_SYNC;

        public List<CRM_ORDER_DRF_SYNC> CRM_ORDER_DRF_SYNC
        {
            get { return _CRM_ORDER_DRF_SYNC; }
            set { _CRM_ORDER_DRF_SYNC = value; }
        }
    }
}
