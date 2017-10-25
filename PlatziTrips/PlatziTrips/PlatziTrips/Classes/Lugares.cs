using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatziTrips.Classes
{
    public class Lugares
    {
        public ResponseVenue response { get; set; }
    }

    public class ResponseVenue
    {
        public List<Venue> venues { get; set; }                
    }

    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }        
        public Location location { get; set; }
        public List<Category> categories { get; set; }                                                
    }

    public class Location
    {
        public string address { get; set; }                                                
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }        
        public string neighborhood { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }
}
