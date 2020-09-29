using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_XZGL_FLFAMX_SELECT
    {
        private List<HR_XZGL_FLFAMX> _HR_XZGL_FLFAMX;

        public List<HR_XZGL_FLFAMX> HR_XZGL_FLFAMX
        {
            get { return _HR_XZGL_FLFAMX; }
            set { _HR_XZGL_FLFAMX = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
