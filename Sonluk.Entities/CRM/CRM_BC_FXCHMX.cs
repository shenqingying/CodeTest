using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_BC_FXCHMX
    {

        int _FXCHMXID;

        public int FXCHMXID
        {
            get { return _FXCHMXID; }
            set { _FXCHMXID = value; }
        }
        int _FXCHTTID;

        public int FXCHTTID
        {
            get { return _FXCHTTID; }
            set { _FXCHTTID = value; }
        }
        
        string _TPM;

        public string TPM
        {
            get { return _TPM; }
            set { _TPM = value; }
        }
        string _DXM;

        public string DXM
        {
            get { return _DXM; }
            set { _DXM = value; }
        }
        string _NHM;

        public string NHM
        {
            get { return _NHM; }
            set { _NHM = value; }
        }
        string _CHARG;

        public string CHARG
        {
            get { return _CHARG; }
            set { _CHARG = value; }
        }
        string _LWEDT;

        public string LWEDT
        {
            get { return _LWEDT; }
            set { _LWEDT = value; }
        }
        bool _ISDELETE;

        public bool ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }




    }
}
