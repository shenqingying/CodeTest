using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MM
{
    public class ScheDelivDestInfo
    {
        private int _ID;
        private string _Destination;
        private int _Status;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Destination
        {
            get { return _Destination; }
            set { _Destination = value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
    }
}
