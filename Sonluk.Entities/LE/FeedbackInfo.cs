using Sonluk.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class FeedbackInfo
    {
        private int _ID;
        private CompanyInfo _Carrier;
        private string _Date;
        private string _DateEnd;
        private decimal _Payment;
        private string _Remark;
        private string _Creator;
        private int _CreatorID;
        private string _CreateDate;
        private int _Status;

        private List<FeedbackItemInfo> _Items;

        private int _ConsignmentNote;
        private string _Destination;
        private string _DepartureDate;
        private string _DepartureDateEnd;
        private string _ItemRemark;

       
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public CompanyInfo Carrier
        {
            get { return _Carrier; }
            set { _Carrier = value; }
        }

        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public string DateEnd
        {
            get { return _DateEnd; }
            set { _DateEnd = value; }
        }
        public decimal Payment
        {
            get { return _Payment; }
            set { _Payment = value; }
        }
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        public string Creator
        {
            get { return _Creator; }
            set { _Creator = value; }
        }
        public int CreatorID
        {
            get { return _CreatorID; }
            set { _CreatorID = value; }
        }
        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public List<FeedbackItemInfo> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        public int ConsignmentNote
        {
            get { return _ConsignmentNote; }
            set { _ConsignmentNote = value; }
        }
        public string Destination
        {
            get { return _Destination; }
            set { _Destination = value; }
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

        public string ItemRemark
        {
            get { return _ItemRemark; }
            set { _ItemRemark = value; }
        }
    }
}
