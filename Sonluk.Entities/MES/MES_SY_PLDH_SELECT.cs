﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_PLDH_SELECT
    {
        private List<MES_SY_PLDH> _MES_SY_PLDH;

        public List<MES_SY_PLDH> MES_SY_PLDH
        {
            get { return _MES_SY_PLDH; }
            set { _MES_SY_PLDH = value; }
        }

        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
