using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_SY_BINDINGDEVICE
    {
        private int _ID;  //ID

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _MACADRESS;  //MACADRESS

        public string MACADRESS
        {
            get { return _MACADRESS; }
            set { _MACADRESS = value; }
        }
        private string _SBBH;  //SBBH

        public string SBBH
        {
            get { return _SBBH; }
            set { _SBBH = value; }
        }
        private int _STAFFID;  //STAFFID

        public int STAFFID
        {
            get { return _STAFFID; }
            set { _STAFFID = value; }
        }
        private int _ISBIND;  //ISBIND

        public int ISBIND
        {
            get { return _ISBIND; }
            set { _ISBIND = value; }
        }
        private int _ISDELETE;  //ISDELETE

        public int ISDELETE
        {
            get { return _ISDELETE; }
            set { _ISDELETE = value; }
        }

    }
}
