using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Contracts.Responses
{
    public class ListingResponse
    {
        public Int64 ListingId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int? UserRating { get; set; }
        public int? Ranking { get; set; }
        public int? PromoRank { get; set; }
        public int? Views { get; set; }
        //public IEnumerable<UsageType> UsageTypes { get; set; }
    }
}
