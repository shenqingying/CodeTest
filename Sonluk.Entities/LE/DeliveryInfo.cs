using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class DeliveryInfo
    {
        private string _SerialNumber;     //VBELN 交货单
        private string _Date;
        private double _ConditionValue;  //KWERT 定价值
        private string _SalesOrganization;        //VKORG 销售组织
        private string _SalesDistr;      //VTWEG 销售渠道

        private string _SalesOrder;
        private string _Customer;
        private string _CustomerName;
        private string _ShipToParty;
        private string _ShipToPartyName;
        private string _City;
        private string _Telephone;
        private string _Address;
        private string _Remark;
        private string _Unit;      
        private string _Type;     
        private decimal _TotalWeight;
        private decimal _NetWeight;
        private string _DeliveryDate;
        private string _DeliveryDateEnd;   
        private string _PickingDate;
        private string _PickingDateEnd; 
        private string _Creator;
        private string _CreateDate;
        private string _CreateDateEnd;
        private string _CreateTime;

        private string _Status;

        private string _ConsignmentNote;
        private string _BillOfLoading;
        private string _StoreLocation;
        private string _Contact;
        private string _ContactTelephone;
        
        

        List<string> _SerialNumberSet;

        private List<DeliveryItemInfo> _Items;

        
             
        public string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }
        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public double ConditionValue
        {
            get { return _ConditionValue; }
            set { _ConditionValue = value; }
        }

        public string SalesOrganization
        {
            get { return _SalesOrganization; }
            set { _SalesOrganization = value; }
        }

        public string SalesDistr
        {
            get { return _SalesDistr; }
            set { _SalesDistr = value; }
        }


        public string SalesOrder
        {
            get { return _SalesOrder; }
            set { _SalesOrder = value; }
        }

        public string Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }
        public string ShipToParty
        {
            get { return _ShipToParty; }
            set { _ShipToParty = value; }
        }
        public string ShipToPartyName
        {
            get { return _ShipToPartyName; }
            set { _ShipToPartyName = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public decimal TotalWeight
        {
            get { return _TotalWeight; }
            set { _TotalWeight = value; }
        }
        public decimal NetWeight
        {
            get { return _NetWeight; }
            set { _NetWeight = value; }
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
        public string PickingDate
        {
            get { return _PickingDate; }
            set { _PickingDate = value; }
        }
        public string PickingDateEnd
        {
            get { return _PickingDateEnd; }
            set { _PickingDateEnd = value; }
        }
        public string Creator
        {
            get { return _Creator; }
            set { _Creator = value; }
        }
        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        public string CreateDateEnd
        {
            get { return _CreateDateEnd; }
            set { _CreateDateEnd = value; }
        }
        public string CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public string ConsignmentNote
        {
            get { return _ConsignmentNote; }
            set { _ConsignmentNote = value; }
        }
        public string BillOfLoading
        {
            get { return _BillOfLoading; }
            set { _BillOfLoading = value; }
        }
        public string StoreLocation
        {
            get { return _StoreLocation; }
            set { _StoreLocation = value; }
        }
        public string Contact
        {
            get { return _Contact; }
            set { _Contact = value; }
        }
        public string ContactTelephone
        {
            get { return _ContactTelephone; }
            set { _ContactTelephone = value; }
        }
        public List<string> SerialNumberSet
        {
            get { return _SerialNumberSet; }
            set { _SerialNumberSet = value; }
        }

        public List<DeliveryItemInfo> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }
    }
}
