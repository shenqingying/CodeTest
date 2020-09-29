using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_MISSION_IMPORT
    {
        string _FUNTYPE;

        public string FUNTYPE
        {
            get { return _FUNTYPE; }
            set { _FUNTYPE = value; }
        }
        string _DATEBEGIN;

        public string DATEBEGIN
        {
            get { return _DATEBEGIN; }
            set { _DATEBEGIN = value; }
        }
        string _DATEEND;

        public string DATEEND
        {
            get { return _DATEEND; }
            set { _DATEEND = value; }
        }
        string _MISSION;

        public string MISSION
        {
            get { return _MISSION; }
            set { _MISSION = value; }
        }
        string _MATNR;

        public string MATNR
        {
            get { return _MATNR; }
            set { _MATNR = value; }
        }
        string _VBELN;

        public string VBELN
        {
            get { return _VBELN; }
            set { _VBELN = value; }
        }
        string _POSNR;

        public string POSNR
        {
            get { return _POSNR; }
            set { _POSNR = value; }
        }
        string _STATUS;

        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }
        string _CJR;

        public string CJR
        {
            get { return _CJR; }
            set { _CJR = value; }
        }
        string _STATUSSTR;

        public string STATUSSTR
        {
            get { return _STATUSSTR; }
            set { _STATUSSTR = value; }
        }

    }
}
