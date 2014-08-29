using Attractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Processor
{
    internal class EntityMapper
    {

        internal static IEnumerable<Listing> Map(IEnumerable<Repository.Models.Listing> listings)
        {
            if (listings == null)
                return null;

            return from item in listings
                   select new Listing
                   {
                       ListingId = item.ListingId,
                       Title = item.Title,
                       ShortDescription = item.ShortDescription,
                       LongDescription = item.LongDescription,
                       Locale = Map(item.Locale),
                       UserRating = item.UserRating,
                       Ranking = item.Ranking,
                       PromoRank = item.PromoRank,
                       Views = item.Views,
                       Location = Map(item.Location),
                       Category = Map(item.Category),
                       UsageTypes = Map(item.UsageTypes)
                   };
        }

        internal static IEnumerable<UsageType> Map(IEnumerable<Repository.Models.UsageType> usageTypes)
        {
            if (usageTypes == null)
                return null;

            return from item in usageTypes
                   select new UsageType
                   {
                        UsageTypeName = item.UsageTypeName,
                        UsageTypeId = item.UsageTypeId
                   };
        }

        internal static Category Map(Repository.Models.Category category)
        {
            if (category == null)
                return null;
            return new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        internal static Location Map(Repository.Models.Location location)
        {
            if (location == null)
                return null;
            return new Location
            {
                LocationId = location.LocationId,
                place_id = location.place_id,
                short_name = location.short_name,
                long_name = location.long_name
            };
        }

        internal static Locale Map(Repository.Models.Locale locale)
        {
            if (locale == null)
                return null;
            return new Locale
            {
                LocaleId = locale.LocaleId,
                LocaleName = locale.LocaleName
            };
        }

        internal static Repository.Models.Listing Map(Listing ContractListing)
        {
            throw new NotImplementedException();
        }

        internal static Listing Map(Repository.Models.Listing listing)
        {
            if (listing == null)
                return null;

            return new Listing
                   {
                       ListingId = listing.ListingId,
                       Title = listing.Title,
                       ShortDescription = listing.ShortDescription,
                       LongDescription = listing.LongDescription,
                       Locale = Map(listing.Locale),
                       UserRating = listing.UserRating,
                       Ranking = listing.Ranking,
                       PromoRank = listing.PromoRank,
                       Views = listing.Views,
                       Location = Map(listing.Location),
                       Category = Map(listing.Category),
                       UsageTypes = Map(listing.UsageTypes)
                   };
        }
    }
}
