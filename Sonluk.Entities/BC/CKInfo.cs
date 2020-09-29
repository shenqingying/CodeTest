using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.BC
{
    public class CKInfo
    {
        private List<ZSL_SDS014> t_ck;

        public List<ZSL_SDS014> T_ck
        {
            get { return t_ck; }
            set { t_ck = value; }
        }
        private List<ZSL_SDS014> t_ck_z;

        public List<ZSL_SDS014> T_ck_z
        {
            get { return t_ck_z; }
            set { t_ck_z = value; }
        }
    }
}
