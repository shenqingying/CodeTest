using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_KH_GROUP_STAFFList
    {
        int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        int _GID;

        public int GID
        {
            get { return _GID; }
            set { _GID = value; }
        }
        string _STAFFIDDES;

        public string STAFFIDDES
        {
            get { return _STAFFIDDES; }
            set { _STAFFIDDES = value; }
        }
        string _GIDDES;

        public string GIDDES
        {
            get { return _GIDDES; }
            set { _GIDDES = value; }
        }
        string _STAFFNO;

        public string STAFFNO
        {
            get { return _STAFFNO; }
            set { _STAFFNO = value; }
        }
    }
}
