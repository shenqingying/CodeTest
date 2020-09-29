using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.EM
{
    public class EM_FILE_PATH
    {
        int _PATHID;

        public int PATHID
        {
            get { return _PATHID; }
            set { _PATHID = value; }
        }
        string _TYPE;

        public string TYPE
        {
            get { return _TYPE; }
            set { _TYPE = value; }
        }
        string _PATH;

        public string PATH
        {
            get { return _PATH; }
            set { _PATH = value; }
        }
        private string _ROLE;

        public string ROLE
        {
            get { return _ROLE; }
            set { _ROLE = value; }
        }
        string _VIRTUALPATH;

        public string VIRTUALPATH
        {
            get { return _VIRTUALPATH; }
            set { _VIRTUALPATH = value; }
        }
        string _IPPATH;

        public string IPPATH
        {
            get { return _IPPATH; }
            set { _IPPATH = value; }
        }
    }
}
