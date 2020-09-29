using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.SSO
{
    public class SSO_TOKEN_USERNAMEDY_SELECT
    {
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        private List<SSO_TOKEN_USERNAMEDY> _SSO_TOKEN_USERNAMEDY;

        public List<SSO_TOKEN_USERNAMEDY> SSO_TOKEN_USERNAMEDY
        {
            get { return _SSO_TOKEN_USERNAMEDY; }
            set { _SSO_TOKEN_USERNAMEDY = value; }
        }
    }
}
