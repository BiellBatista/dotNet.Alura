﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _05_XX_MongoDB.Geocoding
{
    public class GoogleGeocodeResponse
    {

        public string status { get; set; }
        public results[] results { get; set; }

        public override string ToString()
        {
            var result = $"Status: {status}";
            results.ToList().ForEach(r =>
            {
                result += $"\n{r.formatted_address}: ({r.geometry.location.lat},{r.geometry.location.lng})";
            });
            return result;
        }

    }

    public class results
    {
        public string formatted_address { get; set; }
        public geometry geometry { get; set; }
        public string[] types { get; set; }
        public address_component[] address_components { get; set; }
    }

    public class geometry
    {
        public string location_type { get; set; }
        public location location { get; set; }
    }

    public class location
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class address_component
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public string[] types { get; set; }
    }
}