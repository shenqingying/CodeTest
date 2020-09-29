using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_PD_GD_BOM_SELECT
    {
        private List<MES_PD_GD_BOM_LIST> _MES_PD_GD_BOM;

        public List<MES_PD_GD_BOM_LIST> MES_PD_GD_BOM
        {
            get { return _MES_PD_GD_BOM; }
            set { _MES_PD_GD_BOM = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
