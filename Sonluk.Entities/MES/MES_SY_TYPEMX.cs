using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MES
{
    public class MES_SY_TYPEMX
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _TYPEID;

        public int TYPEID
        {
            get { return _TYPEID; }
            set { _TYPEID = value; }
        }

        private string _TYPENAME;

        public string TYPENAME
        {
            get { return _TYPENAME; }
            set { _TYPENAME = value; }
        }

        private string _MXNAME;

        public string MXNAME
        {
            get { return _MXNAME; }
            set { _MXNAME = value; }
        }
        private string _MXNO;

        public string MXNO
        {
            get { return _MXNO; }
            set { _MXNO = value; }
        }

        private string _MXREMARK;

        public string MXREMARK
        {
            get { return _MXREMARK; }
            set { _MXREMARK = value; }
        }

        private string _GC;

        public string GC
        {
            get { return _GC; }
            set { _GC = value; }
        }

        private string _GCNAME;

        public string GCNAME
        {
            get { return _GCNAME; }
            set { _GCNAME = value; }
        }
        private string _MAXVALUE;

        public string MAXVALUE
        {
            get { return _MAXVALUE; }
            set { _MAXVALUE = value; }
        }
        private string _MINVALUE;

        public string MINVALUE
        {
            get { return _MINVALUE; }
            set { _MINVALUE = value; }
        }
    }
}
