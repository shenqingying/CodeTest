﻿using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_XZGL_XZDA_GZLB_SELECT
    {
        private List<HR_XZGL_XZDA_GZLB> _HR_XZGL_XZDA_GZLB;

        public List<HR_XZGL_XZDA_GZLB> HR_XZGL_XZDA_GZLB
        {
            get { return _HR_XZGL_XZDA_GZLB; }
            set { _HR_XZGL_XZDA_GZLB = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
