using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class UnitInfo
    {
        private int _ID;
        private string _Symbol;
        private string _Name;
        private string _Remark;


        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Symbol
        {
            get { return _Symbol; }
            set { _Symbol = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
    }
}
