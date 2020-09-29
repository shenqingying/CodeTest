using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
    public class CRM_BC_FXCHTTList : CRM_BC_FXCHTT
    {
        string _MC;

        public string MC
        {
            get { return _MC; }
            set { _MC = value; }
        }
        string _SAPSN;

        public string SAPSN
        {
            get { return _SAPSN; }
            set { _SAPSN = value; }
        }
        string _SDF_MC;

        public string SDF_MC
        {
            get { return _SDF_MC; }
            set { _SDF_MC = value; }
        }
        string _SDF_SAPSN;

        public string SDF_SAPSN
        {
            get { return _SDF_SAPSN; }
            set { _SDF_SAPSN = value; }
        }
        string _CJRDES;

        public string CJRDES
        {
            get { return _CJRDES; }
            set { _CJRDES = value; }
        }
        int _MXcount;

        public int MXcount
        {
            get { return _MXcount; }
            set { _MXcount = value; }
        }


    }
}
