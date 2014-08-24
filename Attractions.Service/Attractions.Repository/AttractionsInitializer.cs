using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Attractions.Repository.Models;

namespace Attractions.Repository
{
    public class AttractionsInitializer : DropCreateDatabaseIfModelChanges<AttractionsContext>
    {
        protected override void Seed(AttractionsContext context)
        {
            var locales = new List<Locale>
            {
                new Locale { LocaleId = 1 , LocaleName = "English"},
            };
            locales.ForEach(s => context.Locales.Add(s));

            var categories = new List<Category>
            {
                new Category{ CategoryId = 1, CategoryName = "Attractions"},
                new Category{ CategoryId = 2, CategoryName = "Adut Entertainment" },
            };
            categories.ForEach(s => context.Categories.Add(s));

            var usageTypes = new List<UsageType>
            {
                new UsageType{ UsageTypeId = 1, UsageTypeName = "Adults"},
                new UsageType{ UsageTypeId = 2, UsageTypeName = "Kids" },
            };
            usageTypes.ForEach(s => context.UsageTypes.Add(s));

            var locations = new List<Location>
            {
                new Location{ place_id = "ChIJSd7cANJvhlQRXg8TheyzUPM" , short_name = "Capilano Suspension Bridge, Capilano Road, North Vancouver, BC, Canada"},
                new Location{ place_id = "ChIJfRng8uV7hlQRR_VlbIJ18U8" , short_name = "White Pine Beach, Port Moody, BC, Canada", LocationId = 2},
            };
            locations.ForEach(s => context.Locations.Add(s));

            var listings = new List<Listing>
            {
                new Listing{ },
                new Listing{ },
            };
            locations.ForEach(s => context.Locations.Add(s));

            context.SaveChanges();
        }
    }
}
