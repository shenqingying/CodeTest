using Sonluk.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class CNInfo
    {
        private int _ID;
        private CompanyInfo _Carrier;
        private bool _SAP;
        private string _Date;
        private string _DateEnd;
        private int _Total;
        private string _SerialNumber;
        private string _Number;
        private CityInfo _Source;
        private CityInfo _Destination;
        private int _ReceiverEdit;
        private CompanyInfo _Receiver;
        private CompanyInfo _Sender;
        private decimal _Weight;
        private decimal _Volume;  //Add by xsw 2016.05.07 
        private decimal _UnitPrice;
        private decimal _Cost;
        private decimal _Insurance;
        private decimal _DirectCost;
        private decimal _TransitCost;
        private decimal _OtherCost;
        private decimal _TotalCost;
        private int _Compensation;
        private int _DefaultArrivalLimit;
        private int _DeliveryCount;
        private int _InvoiceCount;
        private int _CertificationCount;
        private string _Delivery;
        private string _Instruction;
        private string _Remark;
        private string _DeliveryDate;
        private string _DeliveryDateEnd;
        private bool _PickUpByReceiver;
        private bool _HomeDelivery;
        private bool _PickUpByCertificate;
        private bool _PickUpByFax;
        private bool _Dispatch;
        private bool _Feedback;
        private bool _DeliveryFeedback;
        private bool _Stamp;
        private string _Unload;
        private string _Requirement;
        private bool _FeedbackRecord;
        private bool _ComplaintRecord;
        private int _Status;
        private string _Creator;
        private int _CreatorID;
        private string _CreateDate;
        private bool _JHDFK;
        private string _JHDWHLIST;
        private string _PrintTxt;
        private decimal _ZSCost;
        private int _TYLB;
        private int _FKLB;

        public int FKLB
        {
            get { return _FKLB; }
            set { _FKLB = value; }
        }






        private List<int> _Sum;
        private List<CNItemInfo> _Items;


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
        public bool SAP
        {
            get { return _SAP; }
            set { _SAP = value; }
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
        public string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }
        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        public int Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        public CityInfo Source
        {
            get { return _Source; }
            set { _Source = value; }
        }
        public CityInfo Destination
        {
            get { return _Destination; }
            set { _Destination = value; }
        }
        public int ReceiverEdit
        {
            get { return _ReceiverEdit; }
            set { _ReceiverEdit = value; }
        }
        public CompanyInfo Receiver
        {
            get { return _Receiver; }
            set { _Receiver = value; }
        }
        public CompanyInfo Sender
        {
            get { return _Sender; }
            set { _Sender = value; }
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

        public int Compensation
        {
            get { return _Compensation; }
            set { _Compensation = value; }
        }
        public int DefaultArrivalLimit
        {
            get { return _DefaultArrivalLimit; }
            set { _DefaultArrivalLimit = value; }
        }
        public int DeliveryCount
        {
            get { return _DeliveryCount; }
            set { _DeliveryCount = value; }
        }
        public int InvoiceCount
        {
            get { return _InvoiceCount; }
            set { _InvoiceCount = value; }
        }
        public int CertificationCount
        {
            get { return _CertificationCount; }
            set { _CertificationCount = value; }
        }
        public string Delivery
        {
            get { return _Delivery; }
            set { _Delivery = value; }
        }
        public string Instruction
        {
            get { return _Instruction; }
            set { _Instruction = value; }
        }
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        public string DeliveryDate
        {
            get { return _DeliveryDate; }
            set { _DeliveryDate = value; }
        }
        public string DeliveryDateEnd
        {
            get { return _DeliveryDateEnd; }
            set { _DeliveryDateEnd = value; }
        }
        public bool PickUpByReceiver
        {
            get { return _PickUpByReceiver; }
            set { _PickUpByReceiver = value; }
        }
        public bool HomeDelivery
        {
            get { return _HomeDelivery; }
            set { _HomeDelivery = value; }
        }
        public bool PickUpByCertificate
        {
            get { return _PickUpByCertificate; }
            set { _PickUpByCertificate = value; }
        }
        public bool PickUpByFax
        {
            get { return _PickUpByFax; }
            set { _PickUpByFax = value; }
        }
        public bool Dispatch
        {
            get { return _Dispatch; }
            set { _Dispatch = value; }
        }
        public bool Feedback
        {
            get { return _Feedback; }
            set { _Feedback = value; }
        }
        public bool DeliveryFeedback
        {
            get { return _DeliveryFeedback; }
            set { _DeliveryFeedback = value; }
        }
        public bool Stamp
        {
            get { return _Stamp; }
            set { _Stamp = value; }
        }
        public string Unload
        {
            get { return _Unload; }
            set { _Unload = value; }
        }
        public string Requirement
        {
            get { return _Requirement; }
            set { _Requirement = value; }
        }
        public bool FeedbackRecord
        {
            get { return _FeedbackRecord; }
            set { _FeedbackRecord = value; }
        }
        public bool ComplaintRecord
        {
            get { return _ComplaintRecord; }
            set { _ComplaintRecord = value; }
        }

        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
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
        public List<int> Sum
        {
            get { return _Sum; }
            set { _Sum = value; }
        }
        public List<CNItemInfo> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        public bool JHDFK
        {
            get { return _JHDFK; }
            set { _JHDFK = value; }
        }

        public string JHDWHLIST
        {
            get { return _JHDWHLIST; }
            set { _JHDWHLIST = value; }
        }

        public string PrintTxt
        {
            get { return _PrintTxt; }
            set { _PrintTxt = value; }
        }

        public decimal ZSCost
        {
            get { return _ZSCost; }
            set { _ZSCost = value; }
        }


        public int TYLB
        {
            get { return _TYLB; }
            set { _TYLB = value; }
        }
    }
}
