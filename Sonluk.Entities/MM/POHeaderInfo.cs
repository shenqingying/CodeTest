using Sonluk.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MM
{
    public class POHeaderInfo
    {

        private int _Client;                //MANDT Client  
        private string _Number;             //EBELN Purchasing Document Number
        private string _Company;            //BUKRS Company Code
        private string _CompanyName; 
        private string _Category;           //BSTYP Purchasing Document Category
        private string _Type;               //BSART Purchasing Document Type
        private string _ControlIndicator;   //BSAKZ Control indicator for purchasing document type
        private string _DeletionIndicator;  //LOEKZ Deletion Indicator in Purchasing Document     
        private string _Status;             //STATU Status of Purchasing Document
        private string _CreateDate;         //AEDAT Date on Which Record Was Created
        private string _Creator;            //ERNAM Name of Person who Created the Object
        private string _ItemInterval;       //PINCR Item Number Interval
        private string _LastItem;           //LPONR Last Item Number
        private string _Vendor;             //LIFNR Vendor Account Number
        private string _Language;           //SPRAS Language Key
        private string _PaymentTerms;       //ZTERM Terms of Payment Key
        private string _PurOrg;             //EKORG Purchasing Organization
        private string _PurGroup;           //EKGRP Purchasing Group
        private string _VendorSales;        //VERKF Responsible Salesperson at Vendor's Office
        private string _VendorTelephone;    //LLIEF Vendor's Telephone Number
        private string _Date;               //BEDAT  Purchasing Document Date
        private string _TotalValue;         //RLWRT Total value at time of release
        private string _Currency;           //WAERS Currency Key
        
        private decimal _Tax;       
        private decimal _AmountWithoutTax; 
        private decimal _Amount;

        private string _ReleaseCode;

        

        public int Client
        {
            get { return _Client; }
            set { _Client = value; }
        }
        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }

        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }
        public string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }
        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string ControlIndicator
        {
            get { return _ControlIndicator; }
            set { _ControlIndicator = value; }
        }
        public string DeletionIndicator
        {
            get { return _DeletionIndicator; }
            set { _DeletionIndicator = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        public string Creator
        {
            get { return _Creator; }
            set { _Creator = value; }
        }
        public string ItemInterval
        {
            get { return _ItemInterval; }
            set { _ItemInterval = value; }
        }
        public string LastItem
        {
            get { return _LastItem; }
            set { _LastItem = value; }
        }
        public string Vendor
        {
            get { return _Vendor; }
            set { _Vendor = value; }
        }
        public string Language
        {
            get { return _Language; }
            set { _Language = value; }
        }
        public string PaymentTerms
        {
            get { return _PaymentTerms; }
            set { _PaymentTerms = value; }
        }
        public string PurOrg
        {
            get { return _PurOrg; }
            set { _PurOrg = value; }
        }
        public string PurGroup
        {
            get { return _PurGroup; }
            set { _PurGroup = value; }
        }
        public string VendorSales
        {
            get { return _VendorSales; }
            set { _VendorSales = value; }
        }
        public string VendorTelephone
        {
            get { return _VendorTelephone; }
            set { _VendorTelephone = value; }
        }
        public string Date
        {
            get { return _Date; }
            set { _Date = value; }
        }
        public string TotalValue
        {
            get { return _TotalValue; }
            set { _TotalValue = value; }
        }
        public string Currency
        {
            get { return _Currency; }
            set { _Currency = value; }
        }
        public decimal Tax
        {
            get { return _Tax; }
            set { _Tax = value; }
        }
        public decimal AmountWithoutTax
        {
            get { return _AmountWithoutTax; }
            set { _AmountWithoutTax = value; }
        }
        public decimal Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        public string ReleaseCode
        {
            get { return _ReleaseCode; }
            set { _ReleaseCode = value; }
        }
    
    }
}
