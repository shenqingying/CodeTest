using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_BC_PMLISTList : CRM_BC_PMLIST
    {
        string _CJRDES;

        public string CJRDES
        {
            get { return _CJRDES; }
            set { _CJRDES = value; }
        }
        int _SUOSHU;

        public int SUOSHU
        {
            get { return _SUOSHU; }
            set { _SUOSHU = value; }
        }
    }
}
