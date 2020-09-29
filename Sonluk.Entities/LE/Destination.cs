using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class DestinationInfo
    {
        private int _ID;
        private int _ReceiverID;
        private string _Address;
        private string _Contact;
        private string _Telephone;
        private string _Cellphone;
        private CityInfo _City;
        private bool _Default;

        

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public int ReceiverID
        {
            get { return _ReceiverID; }
            set { _ReceiverID = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string Contact
        {
            get { return _Contact; }
            set { _Contact = value; }
        }
        public string Telephone
        {
            get { return _Telephone; }
            set { _Telephone = value; }
        }
        
        public string Cellphone
        {
            get { return _Cellphone; }
            set { _Cellphone = value; }
        }

        public CityInfo City
        {
            get { return _City; }
            set { _City = value; }
        }
        public bool Default
        {
            get { return _Default; }
            set { _Default = value; }
        }
    }
}
