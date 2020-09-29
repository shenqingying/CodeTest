using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class SELECT_MES_TM_TMINFO_PRINT
    {
        private MES_TM_TMINFO_LIST _MES_TM_TMINFO_LIST;
        public MES_TM_TMINFO_LIST MES_TM_TMINFO_LIST
        {
            get { return _MES_TM_TMINFO_LIST; }
            set { _MES_TM_TMINFO_LIST = value; }
        }

        private List<MES_TM_TMINFO_LIST> _MES_TM_TMINFO_LIST_CHILD;
        public List<MES_TM_TMINFO_LIST> MES_TM_TMINFO_LIST_CHILD
        {
            get { return _MES_TM_TMINFO_LIST_CHILD; }
            set { _MES_TM_TMINFO_LIST_CHILD = value; }
        }

        private string _CZR;

        public string CZR
        {
            get { return _CZR; }
            set { _CZR = value; }
        }

        private MES_RETURN _MES_RETURN;
        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }

        private List<MES_TM_ZFDCMX> _MES_TM_ZFDCMX;

        public List<MES_TM_ZFDCMX> MES_TM_ZFDCMX
        {
            get { return _MES_TM_ZFDCMX; }
            set { _MES_TM_ZFDCMX = value; }
        }
    }
}
