using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Contracts.Requests
{
    public class ListingRequest
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string PlaceId { get; set; } // This is google place_id
        public int CategoryId { get; set; }
    }
}
