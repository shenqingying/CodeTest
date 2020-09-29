using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class PackageInfo
    {
        private int _TypeID;
        private string _Type;


        public int TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
    }
}
