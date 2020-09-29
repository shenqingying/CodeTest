using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_XZGL_FLFA_SELECT
    {
        private List<HR_XZGL_FLFA> _HR_XZGL_FLFA;

        public List<HR_XZGL_FLFA> HR_XZGL_FLFA
        {
            get { return _HR_XZGL_FLFA; }
            set { _HR_XZGL_FLFA = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
