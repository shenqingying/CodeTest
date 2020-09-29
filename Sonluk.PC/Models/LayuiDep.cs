using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models
{
    public class LayuiDep
    {


        private int _id;

        public int DEPID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        string _title;

        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        private int _pdepid;

        public int PDEPID
        {
            get { return _pdepid; }
            set { _pdepid = value; }
        }

        private string _dlevel;

        public string DLEVEL
        {
            get { return _dlevel; }
            set { _dlevel = value; }
        }

        private string _depaddress;

        public string DEPADDRESS
        {
            get { return _depaddress; }
            set { _depaddress = value; }
        }

        private string depmemo;

        public string DEPMEMO
        {
            get { return depmemo; }
            set { depmemo = value; }
        }

        private int _isactive;

        public int ISACTIVE
        {
            get { return _isactive; }
            set { _isactive = value; }
        }

        private string _beiz;

        public string BEIZ
        {
            get { return _beiz; }
            set { _beiz = value; }
        }

        private bool _spread;

        public bool spread
        {
            get { return _spread; }
            set { _spread = value; }
        }




    }
}