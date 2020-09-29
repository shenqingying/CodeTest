using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_MATERIAL_SELECT
    {
        private List<MES_SY_MATERIAL_LIST> _MES_SY_MATERIAL;

        public List<MES_SY_MATERIAL_LIST> MES_SY_MATERIAL
        {
            get { return _MES_SY_MATERIAL; }
            set { _MES_SY_MATERIAL = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
