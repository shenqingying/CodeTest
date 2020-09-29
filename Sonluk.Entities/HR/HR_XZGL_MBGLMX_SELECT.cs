using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_XZGL_MBGLMX_SELECT
    {
        private List<HR_XZGL_MBGLMX> _HR_XZGL_MBGLMX;

        public List<HR_XZGL_MBGLMX> HR_XZGL_MBGLMX
        {
            get { return _HR_XZGL_MBGLMX; }
            set { _HR_XZGL_MBGLMX = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
