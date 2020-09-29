using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_XZGL_FLDATZMX_SELECT_REPORT
    {
        private List<HR_XZGL_FLDATZMX_LIST_REPORT> _HR_XZGL_FLDATZMX_LIST_REPORT;

        public List<HR_XZGL_FLDATZMX_LIST_REPORT> HR_XZGL_FLDATZMX_LIST_REPORT
        {
            get { return _HR_XZGL_FLDATZMX_LIST_REPORT; }
            set { _HR_XZGL_FLDATZMX_LIST_REPORT = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
