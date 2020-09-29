using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.HR
{
    public class HR_RY_LZINFO_LIST
    {
        private string _FSDATE;

        public string FSDATE
        {
            get { return _FSDATE; }
            set { _FSDATE = value; }
        }
        private string _REMARK;

        public string REMARK
        {
            get { return _REMARK; }
            set { _REMARK = value; }
        }
    }
}
