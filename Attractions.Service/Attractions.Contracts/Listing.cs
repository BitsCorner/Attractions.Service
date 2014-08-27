using System.Collections.Generic;
namespace Attractions.Contracts
{
    public class Listing
    {
        public int ListingId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public Locale Locale { get; set; }
        public decimal UserRating { get; set; }
        public decimal Ranking { get; set; }
        public decimal PromoRank { get; set; }
        public decimal Views { get; set; }
        public Location Location { get; set; } // This is google place_id
        public Category Category { get; set; }
        public IEnumerable<UsageType> UsageTypes { get; set; }
    }
}