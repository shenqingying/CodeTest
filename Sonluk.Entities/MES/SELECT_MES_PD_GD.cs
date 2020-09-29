using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class SELECT_MES_PD_GD
    {
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }

        private List<MES_PD_GD_LIST> _MES_PD_GD_LIST;

        public List<MES_PD_GD_LIST> MES_PD_GD_LIST
        {
            get { return _MES_PD_GD_LIST; }
            set { _MES_PD_GD_LIST = value; }
        }
    }
}
