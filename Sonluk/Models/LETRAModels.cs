using Sonluk.UI.Model.LE.TRA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.Models
{
    public class LETRAModels
    {
        private Carrier _Carrier;
        private Sender _Sender;
        private City _City;
        private Route _Route;
        private Price _Price;
        private Receiver _Receiver;
        private Destination _Destination;
        private Goods _Goods;
        private Package _Package;
        private ConsignmentNote _ConsignmentNote;
        private Feedback _Feedback;
        private Complaint _Complaint;
        private Unit _Unit;

        public Carrier Carrier
        {
            get
            {
                if (_Carrier == null)
                    _Carrier = new Carrier();
                return _Carrier;
            }
            set { _Carrier = value; }
        }

        public Sender Sender
        {
            get
            {
                if (_Sender == null)
                    _Sender = new Sender();
                return _Sender;
            }
            set { _Sender = value; }
        }
        public City City
        {
            get
            {
                if (_City == null)
                    _City = new City();
                return _City;
            }
            set { _City = value; }
        }
        public Route Route
        {
            get
            {
                if (_Route == null)
                    _Route = new Route();
                return _Route;
            }
            set { _Route = value; }
        }

        public Price Price
        {
            get
            {
                if (_Price == null)
                    _Price = new Price();
                return _Price;
            }
            set { _Price = value; }
        }
        public Receiver Receiver
        {
            get
            {
                if (_Receiver == null)
                    _Receiver = new Receiver();
                return _Receiver;
            }
            set { _Receiver = value; }
        }
        public Destination Destination
        {
            get
            {
                if (_Destination == null)
                    _Destination = new Destination();
                return _Destination;
            }
            set { _Destination = value; }
        }
        public Goods Goods
        {
            get
            {
                if (_Goods == null)
                    _Goods = new Goods();
                return _Goods;
            }
            set { _Goods = value; }
        }
        public Package Package
        {
            get
            {
                if (_Package == null)
                    _Package = new Package();
                return _Package;
            }
            set { _Package = value; }
        }
        public ConsignmentNote ConsignmentNote
        {
            get
            {
                if (_ConsignmentNote == null)
                    _ConsignmentNote = new ConsignmentNote();
                return _ConsignmentNote;
            }
            set { _ConsignmentNote = value; }
        }
        public Feedback Feedback
        {
            get
            {
                if (_Feedback == null)
                    _Feedback = new Feedback();
                return _Feedback;
            }
            set { _Feedback = value; }
        }

        public Complaint Complaint
        {
            get
            {
                if (_Complaint == null)
                    _Complaint = new Complaint();
                return _Complaint;
            }
            set { _Complaint = value; }
        }
        public Unit Unit
        {
            get
            {
                if (_Unit == null)
                    _Unit = new Unit();
                return _Unit;
            }
            set { _Unit = value; }
        }
    }
}