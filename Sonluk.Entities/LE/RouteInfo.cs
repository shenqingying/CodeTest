using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonluk.Entities.LE
{
    public class RouteInfo
    {
        private int _ID;
        private decimal _Price;
        private int _TimeLimit;
        private string _Arrival;
        private int _CarrierID;
        private string _Carrier; 
        private int _UnitID; 
        private string _Unit;
        private int _SourceID;
        private string _Source;
        private int _DestinationID;
        private string _Destination;
        private int _Distance;
        private int _Zsf;



        private List<PriceInfo> _Prices;

        
       
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        public int TimeLimit
        {
            get { return _TimeLimit; }
            set { _TimeLimit = value; }
        }
        public string Arrival
        {
            get { return _Arrival; }
            set { _Arrival = value; }
        }
        public int CarrierID
        {
            get { return _CarrierID; }
            set { _CarrierID = value; }
        }
        public string Carrier
        {
            get { return _Carrier; }
            set { _Carrier = value; }
        }
        public int UnitID
        {
            get { return _UnitID; }
            set { _UnitID = value; }
        }
        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }

        public int SourceID
        {
            get { return _SourceID; }
            set { _SourceID = value; }
        }
        public string Source
        {
            get { return _Source; }
            set { _Source = value; }
        }
        public int DestinationID
        {
            get { return _DestinationID; }
            set { _DestinationID = value; }
        }
        public string Destination
        {
            get { return _Destination; }
            set { _Destination = value; }
        }
        public int Distance
        {
            get { return _Distance; }
            set { _Distance = value; }
        }

        public List<PriceInfo> Prices
        {
            get { return _Prices; }
            set { _Prices = value; }
        }

        public int Zsf
        {
            get { return _Zsf; }
            set { _Zsf = value; }
        }

    }
}
