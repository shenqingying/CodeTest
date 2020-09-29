using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.MM
{
    public class PurchasingGroupInfo
    {
        private int _Client;
        private string _SerialNumber;
        private string _Description;
        private string _Telephone;
        private string _OutputDevice;
        private string _Fax;
        private string _TelephoneDiallingCode;
        private string _TelephoneExtension;
        private string _EMail;

        
        public int Client
        {
            get { return _Client; }
            set { _Client = value; }
        }
        public string SerialNumber
        {
            get { return _SerialNumber; }
            set { _SerialNumber = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }
        public string OutputDevice
        {
            get { return _OutputDevice; }
            set { _OutputDevice = value; }
        }
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        public string TelephoneDiallingCode
        {
            get { return _TelephoneDiallingCode; }
            set { _TelephoneDiallingCode = value; }
        }
        public string TelephoneExtension
        {
            get { return _TelephoneExtension; }
            set { _TelephoneExtension = value; }
        }
        public string EMail
        {
            get { return _EMail; }
            set { _EMail = value; }
        }

    }
}
