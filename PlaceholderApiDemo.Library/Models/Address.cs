using System;
using System.Collections.Generic;
using System.Text;

namespace PlaceholderApiDemo.Library.Models {
    public class Address {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public GeoLocation Geo { get; set; }
    }
    public class GeoLocation {
        public string Lat { get; set; }
        public string Lng { get; set; }
    }
}
