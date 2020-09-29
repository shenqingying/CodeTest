using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.SAP
{
    public class ZSL_XMXX
    {
        private string _XMMS;

        public string XMMS
        {
            get { return _XMMS; }
            set { _XMMS = value; }
        }
        private string _XMLX;

        public string XMLX
        {
            get { return _XMLX; }
            set { _XMLX = value; }
        }
        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }
        private string _ZCBH;

        public string ZCBH
        {
            get { return _ZCBH; }
            set { _ZCBH = value; }
        }
        private string _POSID;

        public string POSID
        {
            get { return _POSID; }
            set { _POSID = value; }
        }
        private string _PSPID;

        public string PSPID
        {
            get { return _PSPID; }
            set { _PSPID = value; }
        }
    }
}
