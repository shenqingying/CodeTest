using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_XZGL_FFJLZD_SELECT
    {
        private List<HR_XZGL_FFJLZD> _HR_XZGL_FFJLZD;

        public List<HR_XZGL_FFJLZD> HR_XZGL_FFJLZD
        {
            get { return _HR_XZGL_FFJLZD; }
            set { _HR_XZGL_FFJLZD = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
