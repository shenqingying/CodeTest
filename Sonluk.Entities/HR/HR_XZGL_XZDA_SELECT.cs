using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_XZGL_XZDA_SELECT
    {
        private DataTable _DataTable;

        public DataTable DataTable
        {
            get { return _DataTable; }
            set { _DataTable = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        private List<HR_XZGL_XZDA_LIST> _HR_XZGL_XZDA_LIST;

        public List<HR_XZGL_XZDA_LIST> HR_XZGL_XZDA_LIST
        {
            get { return _HR_XZGL_XZDA_LIST; }
            set { _HR_XZGL_XZDA_LIST = value; }
        }
    }
}
