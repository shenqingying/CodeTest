﻿using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_XZGL_KKGLMX_SELECT
    {
        private List<HR_XZGL_KKGLMX_LIST> _HR_XZGL_KKGLMX_LIST;

        public List<HR_XZGL_KKGLMX_LIST> HR_XZGL_KKGLMX_LIST
        {
            get { return _HR_XZGL_KKGLMX_LIST; }
            set { _HR_XZGL_KKGLMX_LIST = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
