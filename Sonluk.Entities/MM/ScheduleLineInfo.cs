using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MM
{
    public class ScheduleLineInfo
    {
        private string _Number;   //EBELN Purchasing Document Number	采购凭证号         
        private int _Item;        //EBELP Item Number of Purchasing Documen  项目编号       
        private int _Line;        //ETENR Delivery Schedule Line Counter  
        private string _Material;
        private string _MaterialDescription;
        private string _PurGroup;
        private string _InitialDate; 
        private string _Date;     //EINDT Item Delivery Date   
        private decimal _InitialQuantity;
        private decimal _Quantity; //MENGE Scheduled Quantity     已计划数量       
        private decimal _PrevQty;  //AMENG Previous Quantity (Delivery Schedule Lines) 上期数量（交货计划行） 
        private decimal _GRQTY;    //WAMNG Quantity of Goods Received     收货数量
        private decimal _IssuedQty;//WAMNG Issued Quantity          发货数量
        private string _Destination;
        private string _DestinationID; 
        private string _SerialNumber;
        private string _SalesOrder;
        private int _SOItem;
        private string _Vendor;       
        private string _Delete;
        private string _Releaser;
        private string _ReleaseDate;
        private string _ReleaseTime;
        private int _Status;
        private string _StatusDescription;

        
        
        public decimal GRQTY
        {
            get { return _GRQTY; }
            set { _GRQTY = value; }
        }
        public decimal PrevQty
        {
            get { return _PrevQty; }
            set { _PrevQty = value; }
        }
        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        public int Item
        {
            get { return _Item; }
            set { _Item = value; }
        }
        public int Line
        {
            get { return _Line; }
            set { _Line = value; }
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

        public string PurGroup
        {
            get { return _PurGroup; }
            set { _PurGroup = value; }
        } 
        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public string InitialDate
        {
            get { return _InitialDate; }
            set { _InitialDate = value; }
        }
        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public decimal InitialQuantity
        {
            get { return _InitialQuantity; }
            set { _InitialQuantity = value; }
        }
        public decimal IssuedQty
        {
            get { return _IssuedQty; }
            set { _IssuedQty = value; }
        }
        public string Destination
        {
            get { return _Destination; }
            set { _Destination = value; }
        }
        public string DestinationID
        {
            get { return _DestinationID; }
            set { _DestinationID = value; }
        }
        public string SalesOrder
        {
            get { return _SalesOrder; }
            set { _SalesOrder = value; }
        }
        public int SOItem
        {
            get { return _SOItem; }
            set { _SOItem = value; }
        }
        public string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }
        public string Releaser
        {
            get { return _Releaser; }
            set { _Releaser = value; }
        }
        public string ReleaseDate
        {
            get { return _ReleaseDate; }
            set { _ReleaseDate = value; }
        }
        public string ReleaseTime
        {
            get { return _ReleaseTime; }
            set { _ReleaseTime = value; }
        }
        public string Vendor
        {
            get { return _Vendor; }
            set { _Vendor = value; }
        }
        public string Delete
        {
            get { return _Delete; }
            set { _Delete = value; }
        }
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public string StatusDescription
        {
            get { return _StatusDescription; }
            set { _StatusDescription = value; }
        }


        
    }
}
