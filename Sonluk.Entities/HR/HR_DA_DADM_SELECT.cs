using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_DA_DADM_SELECT
    {
        private List<HR_DA_DADM_LIST> _HR_DA_DADM_LIST;

        public List<HR_DA_DADM_LIST> HR_DA_DADM_LIST
        {
            get { return _HR_DA_DADM_LIST; }
            set { _HR_DA_DADM_LIST = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
