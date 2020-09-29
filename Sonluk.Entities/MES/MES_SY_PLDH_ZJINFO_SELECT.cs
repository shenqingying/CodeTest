using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_PLDH_ZJINFO_SELECT
    {
        private List<MES_SY_PLDH_ZJINFO> _MES_SY_PLDH_ZJINFO;

        public List<MES_SY_PLDH_ZJINFO> MES_SY_PLDH_ZJINFO
        {
            get { return _MES_SY_PLDH_ZJINFO; }
            set { _MES_SY_PLDH_ZJINFO = value; }
        }
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
