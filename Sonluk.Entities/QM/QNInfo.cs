using Sonluk.Entities.PP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.QM
{
    public class QNInfo
    {
        private string _SerialNumber;
        private int _Defects;                   //ANZFEHLER QANZFEHL4	 
        private decimal _DefectiveQtyExternal;   //I_MGFRD        
        private decimal _DefectiveQtyInternal;  //I_MGEIG       
        private string _SingleUnitToBeInspected; //I_PRUEFLINR	     
        private string _ExternalReference;
        private string _Remark;
        private string _Type;

        private IList<QNItemInfo> _Items;

        private string _Department;
        private string _ResponsibleDept;
        private string _Disqualification;
        private string _Review;
        private string _Rework;
        private string _Creator;
        private string _CreatorCode;
        private string _PurchaseDepartment;
        private string _Product;
        private string _Date;
        private string _Customer;
        private string _Model;
        private string _ReturnOrExchange;
        private string _Complain;
        private string _SalesDepartment;
        private string _Sales;
        private string _ReceiveDate;
        private decimal _Quantity;
        private decimal _Compensate;
        private string _Report;
        private string _Closed;
        private string _Outsourcing;

        private string _Material;
        private string _MaterialDescription;
        private string _Vendor;
        private string _VendorDevice; 
        private string _SemiFinishedStartingDate;
        private string _SemiFinishedEndDate;

        private string _Batch;
        private decimal _Sampling;
        private decimal _DisqualifiedQty;
        private string _Unit;
        private string _DefectType;

        private string _FlowSerialNumber;

        

        

        

        private IList<ProductInfo> _Products;
        private IList<ProductInfo> _Outsourcings;

        public string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }
        public string SingleUnitToBeInspected
        {
            get { return _SingleUnitToBeInspected; }
            set { _SingleUnitToBeInspected = value; }
        }
        public decimal DefectiveQtyInternal
        {
            get { return _DefectiveQtyInternal; }
            set { _DefectiveQtyInternal = value; }
        }
        public decimal DefectiveQtyExternal
        {
            get { return _DefectiveQtyExternal; }
            set { _DefectiveQtyExternal = value; }
        }
        public int Defects
        {
            get { return _Defects; }
            set { _Defects = value; }
        }
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string ExternalReference
        {
            get { return _ExternalReference; }
            set { _ExternalReference = value; }
        }
        public IList<QNItemInfo> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }




        public string ResponsibleDept
        {
            get { return _ResponsibleDept; }
            set { _ResponsibleDept = value; }
        }
        public string Disqualification
        {
            get { return _Disqualification; }
            set { _Disqualification = value; }
        }
        public string Review
        {
            get { return _Review; }
            set { _Review = value; }
        }
        public string Rework
        {
            get { return _Rework; }
            set { _Rework = value; }
        }
        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }
        public string Creator
        {
            get { return _Creator; }
            set { _Creator = value; }
        }
        public string CreatorCode
        {
            get { return _CreatorCode; }
            set { _CreatorCode = value; }
        }
        public string PurchaseDepartment
        {
            get { return _PurchaseDepartment; }
            set { _PurchaseDepartment = value; }
        }
        public string Sales
        {
            get { return _Sales; }
            set { _Sales = value; }
        }
        public string SalesDepartment
        {
            get { return _SalesDepartment; }
            set { _SalesDepartment = value; }
        }
        public string Complain
        {
            get { return _Complain; }
            set { _Complain = value; }
        }
        public string ReturnOrExchange
        {
            get { return _ReturnOrExchange; }
            set { _ReturnOrExchange = value; }
        }
        public string Model
        {
            get { return _Model; }
            set { _Model = value; }
        }
        public string Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }
        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public string Product
        {
            get { return _Product; }
            set { _Product = value; }
        }
        public string Closed
        {
            get { return _Closed; }
            set { _Closed = value; }
        }
        public string Report
        {
            get { return _Report; }
            set { _Report = value; }
        }
        public decimal Compensate
        {
            get { return _Compensate; }
            set { _Compensate = value; }
        }
        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public string ReceiveDate
        {
            get { return _ReceiveDate; }
            set { _ReceiveDate = value; }
        }
        public string Outsourcing
        {
            get { return _Outsourcing; }
            set { _Outsourcing = value; }
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
        public string Vendor
        {
            get { return _Vendor; }
            set { _Vendor = value; }
        }
        public string VendorDevice
        {
            get { return _VendorDevice; }
            set { _VendorDevice = value; }
        }
        public string SemiFinishedStartingDate
        {
            get { return _SemiFinishedStartingDate; }
            set { _SemiFinishedStartingDate = value; }
        }
        public string SemiFinishedEndDate
        {
            get { return _SemiFinishedEndDate; }
            set { _SemiFinishedEndDate = value; }
        }
        public string Batch
        {
            get { return _Batch; }
            set { _Batch = value; }
        }
        public decimal Sampling
        {
            get { return _Sampling; }
            set { _Sampling = value; }
        }
        public decimal DisqualifiedQty
        {
            get { return _DisqualifiedQty; }
            set { _DisqualifiedQty = value; }
        }
        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        public string DefectType
        {
            get { return _DefectType; }
            set { _DefectType = value; }
        }
        public IList<ProductInfo> Products
        {
            get { return _Products; }
            set { _Products = value; }
        }
        public IList<ProductInfo> Outsourcings
        {
            get { return _Outsourcings; }
            set { _Outsourcings = value; }
        }
        public string FlowSerialNumber
        {
            get { return _FlowSerialNumber; }
            set { _FlowSerialNumber = value; }
        }
    }
}
