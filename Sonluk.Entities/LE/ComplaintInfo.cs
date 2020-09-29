using Sonluk.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class ComplaintInfo
    {
        private int _ID;
        private CompanyInfo _Carrier;
        private int _ConsignmentNote;
        private string _ContactLetter;
        private CompanyInfo _Receiver;
        private string _ReturnDate;
        private string _ReturnDateEnd;
        private string _AppointedDeliveryDate;
        private string _AppointedDeliveryDateEnd;
        private string _DeliveryDate;
        private int _DelayDays;
        private int _TypeID;
        private string _Type;
        private bool _PackageDamage;
        private bool _PackagePollution;
        private bool _GoodsGetWet;
        private bool _GoodsDamage;
        private bool _GoodsShortage;
        private decimal _DamageValue; 
        private decimal _ReworkValue;
        private decimal _Compensation;
        private bool _Compensable;
        private bool _Completed; 
        private string _Creator;
        private int _CreatorID;
        private string _CreateDate;
        private int _Status;

        private List<ComplaintItemInfo> _Items;

        private string _Delivery;
        private string _Material;
        private string _MaterialDescription;

        


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
        public int ConsignmentNote
        {
            get { return _ConsignmentNote; }
            set { _ConsignmentNote = value; }
        }
        public string ContactLetter
        {
            get { return _ContactLetter; }
            set { _ContactLetter = value; }
        }
        public CompanyInfo Receiver
        {
            get { return _Receiver; }
            set { _Receiver = value; }
        }
        public string ReturnDate
        {
            get { return _ReturnDate; }
            set { _ReturnDate = value; }
        }
        public string ReturnDateEnd
        {
            get { return _ReturnDateEnd; }
            set { _ReturnDateEnd = value; }
        }
        public string AppointedDeliveryDate
        {
            get { return _AppointedDeliveryDate; }
            set { _AppointedDeliveryDate = value; }
        }
        public string AppointedDeliveryDateEnd
        {
            get { return _AppointedDeliveryDateEnd; }
            set { _AppointedDeliveryDateEnd = value; }
        }
        public string DeliveryDate
        {
            get { return _DeliveryDate; }
            set { _DeliveryDate = value; }
        }
        public int DelayDays
        {
            get { return _DelayDays; }
            set { _DelayDays = value; }
        }
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
        public bool PackageDamage
        {
            get { return _PackageDamage; }
            set { _PackageDamage = value; }
        }
        public bool PackagePollution
        {
            get { return _PackagePollution; }
            set { _PackagePollution = value; }
        }
        public bool GoodsGetWet
        {
            get { return _GoodsGetWet; }
            set { _GoodsGetWet = value; }
        }
        public bool GoodsDamage
        {
            get { return _GoodsDamage; }
            set { _GoodsDamage = value; }
        }
        public bool GoodsShortage
        {
            get { return _GoodsShortage; }
            set { _GoodsShortage = value; }
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
        public decimal Compensation
        {
            get { return _Compensation; }
            set { _Compensation = value; }
        }
        public bool Compensable
        {
            get { return _Compensable; }
            set { _Compensable = value; }
        }
        public bool Completed
        {
            get { return _Completed; }
            set { _Completed = value; }
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

        public List<ComplaintItemInfo> Items
        {
            get { return _Items; }
            set { _Items = value; }
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
    }
}
