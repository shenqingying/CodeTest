using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class PriceInfo
    {
        private int _ID;
        private int _Route;
        private string _Unit;
        private int _UnitID;
        private decimal _LowerWeightLimit;
        private decimal _UpperWeightLimit;
        private decimal _Value;

        
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int Route
        {
            get { return _Route; }
            set { _Route = value; }
        }
        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        public int UnitID
        {
            get { return _UnitID; }
            set { _UnitID = value; }
        }
        public decimal LowerWeightLimit
        {
            get { return _LowerWeightLimit; }
            set { _LowerWeightLimit = value; }
        }
        public decimal UpperWeightLimit
        {
            get { return _UpperWeightLimit; }
            set { _UpperWeightLimit = value; }
        }
        public decimal Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }
}
