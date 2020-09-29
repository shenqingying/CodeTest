using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.WX.Models
{
    public class TXaddress
    {
        public TXaddress()
        {

        }

        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
        public class FormattedAddresses
        {
            public string recommend { get; set; }
            public string rough { get; set; }
        }
        public class AddressComponent
        {
            public string nation { get; set; }
            public string province { get; set; }
            public string city { get; set; }
            public string district { get; set; }
            public string street { get; set; }
            public string street_number { get; set; }
        }
        public class Location2
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
        public class AdInfo
        {
            public string nation_code { get; set; }
            public string adcode { get; set; }
            public string city_code { get; set; }
            public string name { get; set; }
            public Location2 location { get; set; }
            public string nation { get; set; }
            public string province { get; set; }
            public string city { get; set; }
            public string district { get; set; }
        }
        public class Location3
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
        public class StreetNumber
        {
            public string title { get; set; }
            public Location3 location { get; set; }
            public double _distance { get; set; }
            public string _dir_desc { get; set; }
        }
        public class Location4
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
        public class Crossroad
        {
            public string title { get; set; }
            public Location4 location { get; set; }
            public double _distance { get; set; }
            public string _dir_desc { get; set; }
        }
        public class Location5
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
        public class Town
        {
            public string title { get; set; }
            public Location5 location { get; set; }
            public int _distance { get; set; }
            public string _dir_desc { get; set; }
        }
        public class Location6
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
        public class Street
        {
            public string title { get; set; }
            public Location6 location { get; set; }
            public double _distance { get; set; }
            public string _dir_desc { get; set; }
        }
        public class Location7
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
        public class LandmarkL2
        {
            public string title { get; set; }
            public Location7 location { get; set; }
            public double _distance { get; set; }
            public string _dir_desc { get; set; }
        }
        public class AddressReference
        {
            public StreetNumber street_number { get; set; }
            public Crossroad crossroad { get; set; }
            public Town town { get; set; }
            public Street street { get; set; }
            public LandmarkL2 landmark_l2 { get; set; }
        }
        public class Location8
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }
        public class AdInfo2
        {
            public string adcode { get; set; }
            public string province { get; set; }
            public string city { get; set; }
            public string district { get; set; }
        }
        public class Pois
        {
            public string id { get; set; }
            public string title { get; set; }
            public string address { get; set; }
            public string category { get; set; }
            public Location8 location { get; set; }
            public AdInfo2 ad_info { get; set; }
            public double _distance { get; set; }
            public string _dir_desc { get; set; }
        }
        public class Result
        {
            public Location location { get; set; }
            public string address { get; set; }
            public FormattedAddresses formatted_addresses { get; set; }
            public AddressComponent address_component { get; set; }
            public AdInfo ad_info { get; set; }
            public AddressReference address_reference { get; set; }
            public int poi_count { get; set; }
            public IList<Pois> pois { get; set; }
        }


        public int status { get; set; }
        public string message { get; set; }
        public string request_id { get; set; }
        public Result result { get; set; }


    }
}