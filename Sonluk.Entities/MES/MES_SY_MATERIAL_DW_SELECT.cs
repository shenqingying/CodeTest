using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_MATERIAL_DW_SELECT
    {
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        private List<MES_SY_MATERIAL_DW> _MES_SY_MATERIAL_DW;

        public List<MES_SY_MATERIAL_DW> MES_SY_MATERIAL_DW
        {
            get { return _MES_SY_MATERIAL_DW; }
            set { _MES_SY_MATERIAL_DW = value; }
        }
    }
}
