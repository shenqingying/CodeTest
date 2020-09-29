using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_SCRW_SUM_SELECT
    {
        List<MES_PD_SCRW_SUM_LIST> _MES_PD_SCRW_SUM_LIST;

        public List<MES_PD_SCRW_SUM_LIST> MES_PD_SCRW_SUM_LIST
        {
            get { return _MES_PD_SCRW_SUM_LIST; }
            set { _MES_PD_SCRW_SUM_LIST = value; }
        }
        MES_RETURN _MES_RETURN;


        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
     }
}
