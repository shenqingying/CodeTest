using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class ComplaintItemInfo
    {
        private int _ID;
        private int _HeaderID;
        private string _Delivery;
        private string _Material; 
        private string _MaterialDescription;
        private int _ReturnWholeQty;
        private decimal _ReturnQty;
        private string _ReturnReason;
        private decimal _UnitValue;
        private decimal _DamageQty;
        private decimal _DamageValue;
        private decimal _ReworkValue;
        private string _Sales;

     
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int HeaderID
        {
            get { return _HeaderID; }
            set { _HeaderID = value; }
        }
        public string Delivery
        {
            get { return _Delivery; }
            set { _Delivery = value; }
        }
        public string Material
        {
            get { return _Material; }
            set { _Material = value; }
        }
        public string MaterialDescription
        {
            get { return _MaterialDescription; }
            set { _MaterialDescription = value; }
        }
        public decimal ReturnQty
        {
            get { return _ReturnQty; }
            set { _ReturnQty = value; }
        }
        public int ReturnWholeQty
        {
            get { return _ReturnWholeQty; }
            set { _ReturnWholeQty = value; }
        }
        public string ReturnReason
        {
            get { return _ReturnReason; }
            set { _ReturnReason = value; }
        }
        public decimal UnitValue
        {
            get { return _UnitValue; }
            set { _UnitValue = value; }
        }
        public decimal DamageQty
        {
            get { return _DamageQty; }
            set { _DamageQty = value; }
        }
        public decimal DamageValue
        {
            get { return _DamageValue; }
            set { _DamageValue = value; }
        }
        public decimal ReworkValue
        {
            get { return _ReworkValue; }
            set { _ReworkValue = value; }
        }
        public string Sales
        {
            get { return _Sales; }
            set { _Sales = value; }
        }

    }
}
