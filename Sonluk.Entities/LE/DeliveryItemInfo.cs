using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class DeliveryItemInfo
    {
        private string _SerialNumber;     //VBELN 交货单
        private int _Number;
        private string _Material;
        private string _MatlDescription;
        private decimal _Quantity;
        private string _Unit;
        private int _Whole;
        private int _Odd;
        private decimal _GrossWeight;
        private decimal _NetWeight;
        private string _WeightUnit;
        private string _ReferenceDocument;
        private int _ReferenceDocumentItem;
        private string _StgeLoc;
        private string _CustomerMatlDesc;       
        private string _Batch;       
        private decimal _SingleQty;        
        private decimal _SingleWeight;        
        private decimal _SingleVolume; 
        private string _Plant;
        private string _MatlGroup;
        private string _Type; 
        private string _Creator;
        private string _CreateDate;
        private string _CreateTime;
        private int _BatchSplit;
        private string _Status;

        
        
        public string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }
        public int Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        public string Material
        {
            get { return _Material; }
            set { _Material = value; }
        }
        public string MatlDescription
        {
            get { return _MatlDescription; }
            set { _MatlDescription = value; }
        }
        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
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
        public decimal GrossWeight
        {
            get { return _GrossWeight; }
            set { _GrossWeight = value; }
        }
        public decimal NetWeight
        {
            get { return _NetWeight; }
            set { _NetWeight = value; }
        }
        public string WeightUnit
        {
            get { return _WeightUnit; }
            set { _WeightUnit = value; }
        }
        public string ReferenceDocument
        {
            get { return _ReferenceDocument; }
            set { _ReferenceDocument = value; }
        }
        public int ReferenceDocumentItem
        {
            get { return _ReferenceDocumentItem; }
            set { _ReferenceDocumentItem = value; }
        }
        public string StgeLoc
        {
            get { return _StgeLoc; }
            set { _StgeLoc = value; }
        }
        public string CustomerMatlDesc
        {
            get { return _CustomerMatlDesc; }
            set { _CustomerMatlDesc = value; }
        }
        public string Batch
        {
            get { return _Batch; }
            set { _Batch = value; }
        }
        public decimal SingleQty
        {
            get { return _SingleQty; }
            set { _SingleQty = value; }
        }
        public decimal SingleWeight
        {
            get { return _SingleWeight; }
            set { _SingleWeight = value; }
        }
        public decimal SingleVolume
        {
            get { return _SingleVolume; }
            set { _SingleVolume = value; }
        }
        public string Plant
        {
            get { return _Plant; }
            set { _Plant = value; }
        }
        public string MatlGroup
        {
            get { return _MatlGroup; }
            set { _MatlGroup = value; }
        }





        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
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

        public string CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }
        public int BatchSplit
        {
            get { return _BatchSplit; }
            set { _BatchSplit = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
    }
}
