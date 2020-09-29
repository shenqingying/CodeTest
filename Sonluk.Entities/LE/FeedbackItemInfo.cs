using Sonluk.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class FeedbackItemInfo
    {
        private int _ID;
        private int _HeaderID;
        private int _ConsignmentNote;
        private string _DepartureDate;
        private string _DepartureDateEnd;
        private string _Destination;
        private string _GoodsType;
        private int _WholeQty;
        private decimal _Weight;
        private decimal _Volume;
        private decimal _ChargedWeight;
        private decimal _UnitPrice;
        private decimal _Cost;
        private decimal _DirectCost;
        private decimal _HandlingCost;
        private decimal _OtherCost;
        private decimal _TotalCost;
        private decimal _Payment;
        private bool _Confirmed;
        private bool _Normal;
        private string _Remark;

        
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
        public int ConsignmentNote
        {
            get { return _ConsignmentNote; }
            set { _ConsignmentNote = value; }
        }
        public string DepartureDate
        {
            get { return _DepartureDate; }
            set { _DepartureDate = value; }
        }
        public string DepartureDateEnd
        {
            get { return _DepartureDateEnd; }
            set { _DepartureDateEnd = value; }
        }
        public string Destination
        {
            get { return _Destination; }
            set { _Destination = value; }
        }
        public string GoodsType
        {
            get { return _GoodsType; }
            set { _GoodsType = value; }
        }
        public int WholeQty
        {
            get { return _WholeQty; }
            set { _WholeQty = value; }
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
        public decimal ChargedWeight
        {
            get { return _ChargedWeight; }
            set { _ChargedWeight = value; }
        }
        public decimal UnitPrice
        {
            get { return _UnitPrice; }
            set { _UnitPrice = value; }
        }



        public decimal Cost
        {
            get { return _Cost; }
            set { _Cost = value; }
        }
        public decimal DirectCost
        {
            get { return _DirectCost; }
            set { _DirectCost = value; }
        }
        public decimal HandlingCost
        {
            get { return _HandlingCost; }
            set { _HandlingCost = value; }
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


        public decimal Payment
        {
            get { return _Payment; }
            set { _Payment = value; }
        }
        public bool Confirmed
        {
            get { return _Confirmed; }
            set { _Confirmed = value; }
        }
        public bool Normal
        {
            get { return _Normal; }
            set { _Normal = value; }
        }
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
    }
}
