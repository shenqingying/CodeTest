using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_TL_ERROR_SELECT
    {
        private List<MES_PD_TL_ERROR_LIST> _MES_PD_TL_ERROR_LIST;

        public List<MES_PD_TL_ERROR_LIST> MES_PD_TL_ERROR_LIST
        {
            get { return _MES_PD_TL_ERROR_LIST; }
            set { _MES_PD_TL_ERROR_LIST = value; }
        }


        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
