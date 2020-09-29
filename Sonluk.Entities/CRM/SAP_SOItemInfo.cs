using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
  
    public class SAP_SOItemInfo
    {
        private string _SONumber;          
        private int _Number;               
        private int _Client;
        private string _Material;          //物料号	
        private string _MaterialEntered; 
        private decimal _Quantity;         //数量      
        private double _ReqQty;           
        private string _SalesUnit;         //销售单位
        private string _SalesDescription;  
        private string _MatlDesc;          
        private string _ReqmtsType;        
        private string _MatlGroup;        
        private string _Date;             
        private string _RecTime;           
        private string _ChangedDate;      
        private string _Plant;            
        private string _ReqDate;          
        private string _Creator;           
        private string _Remarks;          
        private string _RequestPallet;    
        private string _RequestSpecific;  
        private string _RequestShrinkFilm; 
        private string _RequestRemarks;   
        private string _StartDate;        
        private string _ProcType;          
        private string _DelivStatus;       
        private string _PO;               
        private int _POItem;            
        private string _Status;            
        private string _StatusDesc;        
        private string _CurrentDate;       
        private string _CurrentTime;       
        private string _Vendor;            
        private string _Flag;             
        private string _Type;              
        private string _ProcessingRecordsStatus;  
        private string _ProcessingRecordsDelete;  


        public int Client
        {
            get { return _Client; }
            set { _Client = value; }
        }
        public string SONumber
        {
            get { return _SONumber; }
            set { _SONumber = value; }
        }
        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        /// <summary>
        /// 物料号
        /// </summary>
        public string Material
        {
            get { return _Material; }
            set { _Material = value; }
        }
        public string MaterialEntered
        {
            get { return _MaterialEntered; }
            set { _MaterialEntered = value; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public double ReqQty
        {
            get { return _ReqQty; }
            set { _ReqQty = value; }
        }
        /// <summary>
        /// 销售单位
        /// </summary>
        public string SalesUnit
        {
            get { return _SalesUnit; }
            set { _SalesUnit = value; }
        }
        public string SalesDescription
        {
            get { return _SalesDescription; }
            set { _SalesDescription = value; }
        }
        public string MatlDesc
        {
            get { return _MatlDesc; }
            set { _MatlDesc = value; }
        }
        public string ReqmtsType
        {
            get { return _ReqmtsType; }
            set { _ReqmtsType = value; }
        }
        public string MatlGroup
        {
            get { return _MatlGroup; }
            set { _MatlGroup = value; }
        }
        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public string RecTime
        {
            get { return _RecTime; }
            set { _RecTime = value; }
        }
        public string ChangedDate
        {
            get { return _ChangedDate; }
            set { _ChangedDate = value; }
        }
        public string Plant
        {
            get { return _Plant; }
            set { _Plant = value; }
        }
        public string ReqDate
        {
            get { return _ReqDate; }
            set { _ReqDate = value; }
        }
        public string Creator
        {
            get { return _Creator; }
            set { _Creator = value; }
        }
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        public string RequestPallet
        {
            get { return _RequestPallet; }
            set { _RequestPallet = value; }
        }
        public string RequestSpecific
        {
            get { return _RequestSpecific; }
            set { _RequestSpecific = value; }
        }
        public string RequestShrinkFilm
        {
            get { return _RequestShrinkFilm; }
            set { _RequestShrinkFilm = value; }
        }
        public string RequestRemarks
        {
            get { return _RequestRemarks; }
            set { _RequestRemarks = value; }
        }
        public string StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }
        public string ProcType
        {
            get { return _ProcType; }
            set { _ProcType = value; }
        }
        public string DelivStatus
        {
            get { return _DelivStatus; }
            set { _DelivStatus = value; }
        }
        public string PO
        {
            get { return _PO; }
            set { _PO = value; }
        }
        public int POItem
        {
            get { return _POItem; }
            set { _POItem = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public string StatusDesc
        {
            get { return _StatusDesc; }
            set { _StatusDesc = value; }
        }
        public string CurrentDate
        {
            get { return _CurrentDate; }
            set { _CurrentDate = value; }
        }
        public string CurrentTime
        {
            get { return _CurrentTime; }
            set { _CurrentTime = value; }
        }
        public string Vendor
        {
            get { return _Vendor; }
            set { _Vendor = value; }
        }
        public string Flag
        {
            get { return _Flag; }
            set { _Flag = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string ProcessingRecordsStatus
        {
            get { return _ProcessingRecordsStatus; }
            set { _ProcessingRecordsStatus = value; }
        }
        public string ProcessingRecordsDelete
        {
            get { return _ProcessingRecordsDelete; }
            set { _ProcessingRecordsDelete = value; }
        }

    }
}
