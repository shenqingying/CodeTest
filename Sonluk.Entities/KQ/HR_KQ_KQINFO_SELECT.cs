using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.KQ
{
    public class HR_KQ_KQINFO_SELECT
    {
        private List<HR_KQ_KQINFO> _HR_KQ_KQINFO_LIST;

        public List<HR_KQ_KQINFO> HR_KQ_KQINFO_LIST
        {
            get { return _HR_KQ_KQINFO_LIST; }
            set { _HR_KQ_KQINFO_LIST = value; }
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
