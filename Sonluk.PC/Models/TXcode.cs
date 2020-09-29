using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sonluk.PC.Models
{
    public class TXcode
    {
        
        public class Location
        {
            public double lng { get; set; }
            public double lat { get; set; }
        }
        public class AddressComponents
        {
            public string province { get; set; }
            public string city { get; set; }
            public string district { get; set; }
            public string street { get; set; }
            public string street_number { get; set; }
        }
        public class Result
        {
            public string title { get; set; }
            public Location location { get; set; }
            public AddressComponents address_components { get; set; }
            public double similarity { get; set; }
            public int deviation { get; set; }
            public int reliability { get; set; }
            public int level { get; set; }
        }
        public class TXzcode
        {
            public int status { get; set; }
            public string message { get; set; }
            public Result result { get; set; }
        }

    }
}