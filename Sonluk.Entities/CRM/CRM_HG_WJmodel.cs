using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_HG_WJmodel
    {
        CRM_HG_WJJL _WJJL;

        public CRM_HG_WJJL WJJL
        {
            get { return _WJJL; }
            set { _WJJL = value; }
        }
        CRM_HG_WJJLTT _WJJLTT;

        public CRM_HG_WJJLTT WJJLTT
        {
            get { return _WJJLTT; }
            set { _WJJLTT = value; }
        }
    }
}
