using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_STAFF_QD
    {
        string _STAFFNAME;

        public string STAFFNAME
        {
            get { return _STAFFNAME; }
            set { _STAFFNAME = value; }
        }
        int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        string _STAFFNO;

        public string STAFFNO
        {
            get { return _STAFFNO; }
            set { _STAFFNO = value; }
        }




        List<CRM_KQ_QD> _CRM_KQ_QD;

        public List<CRM_KQ_QD> CRM_KQ_QD
        {
            get { return _CRM_KQ_QD; }
            set { _CRM_KQ_QD = value; }
        } 
    }
}
