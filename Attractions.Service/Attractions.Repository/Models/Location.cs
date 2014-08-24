using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Repository.Models
{
    public class Location
    {
        // some limited values cached from google places api in case the place_id changed
        // at least we should keep the country/state/city/alt/lng
        public string LocationId { get; set; }
        public string place_id { get; set; }
        public string short_name { get; set; }
        public string long_name { get; set; }
        public IEnumerable<string> types { get; set; }
        public int alt { get; set; }
        public int lng { get; set; }
    }
}
