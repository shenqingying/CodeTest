﻿using Sonluk.Entities.MES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_SY_DUTY_SELECT
    {
        private List<HR_SY_DUTY_LIST> _HR_SY_DUTY_LIST;

        public List<HR_SY_DUTY_LIST> HR_SY_DUTY_LIST
        {
            get { return _HR_SY_DUTY_LIST; }
            set { _HR_SY_DUTY_LIST = value; }
        }
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
    }
}
