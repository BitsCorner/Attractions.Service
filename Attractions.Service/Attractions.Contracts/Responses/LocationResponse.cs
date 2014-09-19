using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Contracts.Responses
{
    public class LocationResponse
    {
        public int LocationId { get; set; }
        public string GooglePlaceId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Url { get; set; }

    }
}
