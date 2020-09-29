using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_SY_DEPT_SELECT
    {
        private List<HR_SY_DEPT_LIST> _HR_SY_DEPT_LIST;

        public List<HR_SY_DEPT_LIST> HR_SY_DEPT_LIST
        {
            get { return _HR_SY_DEPT_LIST; }
            set { _HR_SY_DEPT_LIST = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        private DataTable _DATALIST;

        public DataTable DATALIST
        {
            get { return _DATALIST; }
            set { _DATALIST = value; }
        }
    }
}
