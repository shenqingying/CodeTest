using Sonluk.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_Mobile_Login
    {
        MES_LoginINFO _MES_LoginINFO;

        public MES_LoginINFO MES_LoginINFO
        {
            get { return _MES_LoginINFO; }
            set { _MES_LoginINFO = value; }
        }
        MES_RIGHT_ROLE _MES_RIGHT_ROLE;

        public MES_RIGHT_ROLE MES_RIGHT_ROLE
        {
            get { return _MES_RIGHT_ROLE; }
            set { _MES_RIGHT_ROLE = value; }
        }
        CRM_HG_STAFF _CRM_HG_STAFF;

        public CRM_HG_STAFF CRM_HG_STAFF
        {
            get { return _CRM_HG_STAFF; }
            set { _CRM_HG_STAFF = value; }
        }
    }
}
