using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class CNItemInfo
    {
        private int _ID;
        private int _Header;
        private GoodsInfo _GoodsType;
        private PackageInfo _PackageType;
        private int _Whole;
        private int _Odd;
        private int _Total;
        private decimal _Weight;
        private decimal _Volume;
        private decimal _UnitPrice;
        private decimal _UnitInsurance;
        private decimal _Cost;
        private decimal _Insurance;
        private decimal _DirectCost;
        private decimal _TransitCost;
        private decimal _OtherCost;
        private decimal _TotalCost;
  


        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int Header
        {
            get { return _Header; }
            set { _Header = value; }
        }
        public GoodsInfo GoodsType
        {
            get { return _GoodsType; }
            set { _GoodsType = value; }
        }
        public PackageInfo PackageType
        {
            get { return _PackageType; }
            set { _PackageType = value; }
        }
        public int Whole
        {
            get { return _Whole; }
            set { _Whole = value; }
        }
        public int Odd
        {
            get { return _Odd; }
            set { _Odd = value; }
        }
        public int Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        public decimal Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
        public decimal Volume
        {
            get { return _Volume; }
            set { _Volume = value; }
        }
        public decimal UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }
        public decimal UnitInsurance
        {
            get { return _UnitInsurance; }
            set { _UnitInsurance = value; }
        }
        public decimal Cost
        {
            get { return _Cost; }
            set { _Cost = value; }
        }
        public decimal Insurance
        {
            get { return _Insurance; }
            set { _Insurance = value; }
        }
        public decimal DirectCost
        {
            get { return _DirectCost; }
            set { _DirectCost = value; }
        }
        public decimal TransitCost
        {
            get { return _TransitCost; }
            set { _TransitCost = value; }
        }
        public decimal OtherCost
        {
            get { return _OtherCost; }
            set { _OtherCost = value; }
        }
        public decimal TotalCost
        {
            get { return _TotalCost; }
            set { _TotalCost = value; }
        }

      
    }
}
