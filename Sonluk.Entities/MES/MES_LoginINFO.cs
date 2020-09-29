using Sonluk.Entities.Account;
using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_LoginINFO
    {
        private TokenInfo _TokenInfo;

        public TokenInfo TokenInfo
        {
            get { return _TokenInfo; }
            set { _TokenInfo = value; }
        }

        private List<CRM_JURISDICTION_GROUP> _JURISDICTION_GROUP;

        public List<CRM_JURISDICTION_GROUP> JURISDICTION_GROUP
        {
            get { return _JURISDICTION_GROUP; }
            set { _JURISDICTION_GROUP = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
