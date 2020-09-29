using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_BC_FXCHParam
    {
        string _MC;

        public string MC
        {
            get { return _MC; }
            set { _MC = value; }
        }

        string _CRMID;

        public string CRMID
        {
            get { return _CRMID; }
            set { _CRMID = value; }
        }

        string _DXM;

        public string DXM
        {
            get { return _DXM; }
            set { _DXM = value; }
        }

        string _TPM;

        public string TPM
        {
            get { return _TPM; }
            set { _TPM = value; }
        }

        string _NHM;

        public string NHM
        {
            get { return _NHM; }
            set { _NHM = value; }
        }

        int _STAFFID;

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }

        string _Barcode;

        public string Barcode
        {
            get { return _Barcode; }
            set { _Barcode = value; }
        }

    }
}
