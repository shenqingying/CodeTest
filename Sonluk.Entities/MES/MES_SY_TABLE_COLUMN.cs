using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_TABLE_COLUMN
    {
        private string _SY;

        public string SY
        {
            get { return _SY; }
            set { _SY = value; }
        }
        private string _SY_TABLE;

        public string SY_TABLE
        {
            get { return _SY_TABLE; }
            set { _SY_TABLE = value; }
        }
        private string _ZJVALUES;

        public string ZJVALUES
        {
            get { return _ZJVALUES; }
            set { _ZJVALUES = value; }
        }
        private int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
    }
}
