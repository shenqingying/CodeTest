using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_RIGHT_ROLE
    {
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }


        private List<CRM_HG_RIGHT> _CRM_HG_RIGHT;

        public List<CRM_HG_RIGHT> CRM_HG_RIGHT
        {
            get { return _CRM_HG_RIGHT; }
            set { _CRM_HG_RIGHT = value; }
        }

        private List<CRM_HG_RIGHTGROUP> _CRM_HG_RIGHTGROUP;

        public List<CRM_HG_RIGHTGROUP> CRM_HG_RIGHTGROUP
        {
            get { return _CRM_HG_RIGHTGROUP; }
            set { _CRM_HG_RIGHTGROUP = value; }
        }
    }
}
