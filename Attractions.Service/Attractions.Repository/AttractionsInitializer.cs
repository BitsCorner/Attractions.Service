using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Attractions.Repository.Models;

namespace Attractions.Repository
{
    public class AttractionsInitializer : DropCreateDatabaseAlways<AttractionsContext>
    {
        protected override void Seed(AttractionsContext context)
        {
            var locales = new List<Locale>
            {
                new Locale { LocaleId = 1 , LocaleName = "English"},
            };
            locales.ForEach(s => context.Locales.Add(s));
            context.SaveChanges();

            var categories = new List<Category>
            {
                new Category{ CategoryId = 1, CategoryName = "Attractions"},
                new Category{ CategoryId = 2, CategoryName = "Adut Entertainment" },
            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            var usageTypes = new List<UsageType>
            {
                new UsageType{ UsageTypeId = 1, UsageTypeName = "Adults"},
                new UsageType{ UsageTypeId = 2, UsageTypeName = "Kids" },
            };
            usageTypes.ForEach(s => context.UsageTypes.Add(s));
            context.SaveChanges();

            var locations = new List<Location>
            {
                new Location{ place_id = "ChIJSd7cANJvhlQRXg8TheyzUPM" , short_name = "Capilano Suspension Bridge, Capilano Road, North Vancouver, BC, Canada"},
                new Location{ place_id = "ChIJfRng8uV7hlQRR_VlbIJ18U8" , short_name = "White Pine Beach, Port Moody, BC, Canada", LocationId = 2},
            };
            locations.ForEach(s => context.Locations.Add(s));
            context.SaveChanges();

            var listings = new List<Listing>
            {
                new Listing{ Category = new Category { CategoryId = 1 }, ListingId = 1 , Locale = new Locale{ LocaleId = 1 }, Location = new Location { LocationId = 1}, LongDescription = "Capilano Suspension Bridge", PromoRank = 1 , Ranking = 2, ShortDescription = "Capilano Bridge" , Title = "Capilano Suspention Bridge", UsageTypes = null, UserRating = 1, Views = 10 },
                new Listing{ Category = new Category { CategoryId = 1 }, ListingId = 1 , Locale = new Locale{ LocaleId = 1 }, Location = new Location { LocationId = 2}, LongDescription = "White Pine Beach", PromoRank = 2 , Ranking = 1, ShortDescription = "White Pine Beach" , Title = "White Pine Beach", UsageTypes = null, UserRating = 2, Views = 9 },
            };
            listings.ForEach(s => context.Listings.Add(s));
            context.SaveChanges();
        }
    }

}
