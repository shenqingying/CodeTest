using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_JURISDICTION_GROUP
    {
        CRM_HG_RIGHTGROUP _CRM_HG_RIGHTGROUP;

        public CRM_HG_RIGHTGROUP CRM_HG_RIGHTGROUP
        {
            get { return _CRM_HG_RIGHTGROUP; }
            set { _CRM_HG_RIGHTGROUP = value; }
        }
        List<CRM_HG_RIGHT> _CRM_HG_RIGHTList;

        public List<CRM_HG_RIGHT> CRM_HG_RIGHTList
        {
            get { return _CRM_HG_RIGHTList; }
            set { _CRM_HG_RIGHTList = value; }
        }
        int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
    }
}
