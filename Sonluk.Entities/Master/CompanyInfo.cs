using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.Master
{
    public class CompanyInfo
    {
        private string _SerialNumber;
        private string _Name;
        private string _ShortName;
        private string _CountKey;
        private string _City;
        private int _CityID;
        private string _District;
        private string _Address;
        private string _PostCode;
        private string _Telephone;
        private string _Contact;

        
        private string _Cellphone;
        private int _ID;
        
        
        private string _Fax;
        private string _EMail;
        private string _SalesOffices;
        private bool _Default;

        private List<CompanyInfo> _Children;
        private List<CompanyGeneralInfo> _General;

          
        public string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string ShortName
        {
            get { return _ShortName; }
            set { _ShortName = value; }
        }
        public string CountKey
        {
            get { return _CountKey; }
            set { _CountKey = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        public int CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }
        public string District
        {
            get { return _District; }
            set { _District = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string PostCode
        {
            get { return _PostCode; }
            set { _PostCode = value; }
        }
        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }
        public string Contact
        {
            get { return _Contact; }
            set { _Contact = value; }
        }
        public string Cellphone
        {
            get { return _Cellphone; }
            set { _Cellphone = value; }
        }
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        public string EMail
        {
            get { return _EMail; }
            set { _EMail = value; }
        }
        public string SalesOffices
        {
            get { return _SalesOffices; }
            set { _SalesOffices = value; }
        }
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public bool Default
        {
            get { return _Default; }
            set { _Default = value; }
        }
        public List<CompanyInfo> Children
        {
            get { return _Children; }
            set { _Children = value; }
        }
        public List<CompanyGeneralInfo> General
        {
            get { return _General; }
            set { _General = value; }
        } 
    }
}
