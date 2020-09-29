using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.CRM
{
  
    public class SAP_ReportInfo
    {
        private string _Customer;
        private string _CustomerName;
        private string _CustomerPO;
        private string _Date;
        private string _SalesOrder;
        private string _SalesOrderItem;
        private string _Material;
        private string _MaterialDescription;


        private string _DeliveryDate;
        private string _Delivery;
        private string _DeliveryItem;
        private string _Type;
        private decimal _Payable;   //ARA  本期应收
        private decimal _Receivable;//RAA 本期应付
        private decimal _Balance; //BAA  结余金额
        private string _Invoice;
        private string _Currency;
        private string _Remark;


        private string _SOCustomerText;
        private decimal _Quantity;
        private decimal _QuantityDelivered;




        private string _Unit;
        private string _UnitDescription;
        private decimal _Price;
        private decimal _Amount;
        private string _Unit2;
        private decimal _JE;

        private string _SalesOrganization;             //I_VKORG	TYPE	VBAK-VKORG	                     	销售组织 
        private string _DistributionChannel;           //I_VTWEG	TYPE	VBAK-VTWEG	                     	分销渠道
        private string _Division;


        private decimal _AvailableDiscount;
        private decimal _IncreaseDiscount;
        private decimal _DecreaseDiscount;
        private string _DocumentChangeNumber;

        private decimal _SalesOrderDiscount;

        public decimal SalesOrderDiscount
        {
            get { return _SalesOrderDiscount; }
            set { _SalesOrderDiscount = value; }
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

        public string CustomerPO
        {
            get { return _CustomerPO; }
            set { _CustomerPO = value; }
        }
        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public string SalesOrder
        {
            get { return _SalesOrder; }
            set { _SalesOrder = value; }
        }
        public string SalesOrderItem
        {
            get { return _SalesOrderItem; }
            set { _SalesOrderItem = value; }
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
        public string DeliveryDate
        {
            get { return _DeliveryDate; }
            set { _DeliveryDate = value; }
        }
        public string Delivery
        {
            get { return _Delivery; }
            set { _Delivery = value; }
        }
        public string DeliveryItem
        {
            get { return _DeliveryItem; }
            set { _DeliveryItem = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public decimal Payable
        {
            get { return _Payable; }
            set { _Payable = value; }
        }
        public decimal Receivable
        {
            get { return _Receivable; }
            set { _Receivable = value; }
        }
        public decimal Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        public string Invoice
        {
            get { return _Invoice; }
            set { _Invoice = value; }
        }
        public string Currency
        {
            get { return _Currency; }
            set { _Currency = value; }
        }
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        public string SOCustomerText
        {
            get { return _SOCustomerText; }
            set { _SOCustomerText = value; }
        }
        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        public decimal QuantityDelivered
        {
            get { return _QuantityDelivered; }
            set { _QuantityDelivered = value; }
        }
        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }
        public string UnitDescription
        {
            get { return _UnitDescription; }
            set { _UnitDescription = value; }
        }
        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        public decimal Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        public string Unit2
        {
            get { return _Unit2; }
            set { _Unit2 = value; }
        }

        public decimal JE
        {
            get { return _JE; }
            set { _JE = value; }
        }

        public string SalesOrganization
        {
            get { return _SalesOrganization; }
            set { _SalesOrganization = value; }
        }
        public string DistributionChannel
        {
            get { return _DistributionChannel; }
            set { _DistributionChannel = value; }
        }
        public string Division
        {
            get { return _Division; }
            set { _Division = value; }
        }

        public decimal DecreaseDiscount
        {
            get { return _DecreaseDiscount; }
            set { _DecreaseDiscount = value; }
        }
        public decimal IncreaseDiscount
        {
            get { return _IncreaseDiscount; }
            set { _IncreaseDiscount = value; }
        }
        public decimal AvailableDiscount
        {
            get { return _AvailableDiscount; }
            set { _AvailableDiscount = value; }
        }
        public string DocumentChangeNumber
        {
            get { return _DocumentChangeNumber; }
            set { _DocumentChangeNumber = value; }
        }

    }
}
