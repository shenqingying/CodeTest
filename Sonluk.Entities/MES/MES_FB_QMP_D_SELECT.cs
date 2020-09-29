using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_FB_QMP_D_SELECT
    {
        private MES_RETURN _MES_RETURN;

        public MES_RETURN MES_RETURN
        {
            get { return _MES_RETURN; }
            set { _MES_RETURN = value; }
        }
        private DataTable _DATALIST;

        public DataTable DATALIST
        {
            get { return _DATALIST; }
            set { _DATALIST = value; }
        }
    }
}
