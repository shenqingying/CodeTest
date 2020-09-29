using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_MATERIAL_BZCOUNT_SELECT
    {
        private List<MES_SY_MATERIAL_BZCOUNT> _MES_SY_MATERIAL_BZCOUNT;

        public List<MES_SY_MATERIAL_BZCOUNT> MES_SY_MATERIAL_BZCOUNT
        {
            get { return _MES_SY_MATERIAL_BZCOUNT; }
            set { _MES_SY_MATERIAL_BZCOUNT = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
