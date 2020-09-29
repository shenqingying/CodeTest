using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_FB_QMP_TM
    {
        private string _ExcelServerRCID;

        public string ExcelServerRCID
        {
            get { return _ExcelServerRCID; }
            set { _ExcelServerRCID = value; }
        }
        private string _TM;

        public string TM
        {
            get { return _TM; }
            set { _TM = value; }
        }
    }
}
