using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.Master
{
    public class CompanyGeneralInfo
    {
        private string _Client;           //MANDT	MANDT	CLNT	3	0	Client
        private string _Number;   //KUNNR	KUNNR	CHAR	10	0	Customer Number
        private string _CountryKey;       //LAND1	LAND1_GP	CHAR	3	0	Country Key
        private string _Name;       
        private string _Name1;            //NAME1	NAME1_GP	CHAR	35	0	Name 1
        private string _Name2;            //NAME2	NAME2_GP	CHAR	35	0	Name 2
        private string _City;             //ORT01	ORT01_GP	CHAR	35	0	City
        private string _PostalCode;       //PSTLZ	PSTLZ	CHAR	10	0	Postal Code
        private string _Region;           //REGIO	REGIO	CHAR	3	0	Region (State, Province, County)
        private string _SortField;        //SORTL	SORTL	CHAR	10	0	Sort field
        private string _HouseNumberAndStreet;//STRAS	STRAS_GP	CHAR	35	0	House number and street
        private string _FirstTelephoneNumber;//TELF1	TELF1	CHAR	16	0	First telephone number
        private string _FaxNumber;           //TELFX	TELFX	CHAR	31	0	Fax Number
        private string _Address;             //ADRNR	ADRNR	CHAR	10	0	Address

        private string _SalesOrganization;            
        private string _SalesOrganizationDescription;
        private string _DistributionChannel;           
        private string _DistributionChannelDescription;
        private string _Division;
        private string _DivisionDescription;
        private string _SalesGroup;
        private string _SalesGroupDescription;
        private string _Telephone;

        
        public string Client
        {
            get { return _Client; }
            set { _Client = value; }
        }
        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }
        public string CountryKey
        {
            get { return _CountryKey; }
            set { _CountryKey = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Name1
        {
            get { return _Name1; }
            set { _Name1 = value; }
        }
        public string Name2
        {
            get { return _Name2; }
            set { _Name2 = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }
        public string Region
        {
            get { return _Region; }
            set { _Region = value; }
        }
        public string SortField
        {
            get { return _SortField; }
            set { _SortField = value; }
        }
        public string HouseNumberAndStreet
        {
            get { return _HouseNumberAndStreet; }
            set { _HouseNumberAndStreet = value; }
        }
        public string FirstTelephoneNumber
        {
            get { return _FirstTelephoneNumber; }
            set { _FirstTelephoneNumber = value; }
        }
        public string FaxNumber
        {
            get { return _FaxNumber; }
            set { _FaxNumber = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }


        public string SalesOrganization
        {
            get { return _SalesOrganization; }
            set { _SalesOrganization = value; }
        }
        public string SalesOrganizationDescription
        {
            get { return _SalesOrganizationDescription; }
            set { _SalesOrganizationDescription = value; }
        }
        public string DistributionChannel
        {
            get { return _DistributionChannel; }
            set { _DistributionChannel = value; }
        }
        public string DistributionChannelDescription
        {
            get { return _DistributionChannelDescription; }
            set { _DistributionChannelDescription = value; }
        }
        public string Division
        {
            get { return _Division; }
            set { _Division = value; }
        }
        public string DivisionDescription
        {
            get { return _DivisionDescription; }
            set { _DivisionDescription = value; }
        }
        public string SalesGroup
        {
            get { return _SalesGroup; }
            set { _SalesGroup = value; }
        }
        public string SalesGroupDescription
        {
            get { return _SalesGroupDescription; }
            set { _SalesGroupDescription = value; }
        }
        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }

    }
}
