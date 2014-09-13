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

        internal static IEnumerable<Listing> Map(IEnumerable<Repository.AttractionsListing> listings)
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
                       //Locale = Map(item.Locale),
                       UserRating = item.UserRating,
                       Ranking = item.Ranking,
                       PromoRank = item.PromoRanking,
                       //Views = item.Views,
                       Location = Map(item.AttractionsLocation),
                       Category = Map(item.AttractionsCategory),
                       UsageTypes = Map(item.AttractionsUsageTypes)
                   };
        }

        internal static IEnumerable<UsageType> Map(IEnumerable<Repository.AttractionsUsageType> usageTypes)
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

        internal static IEnumerable<Category> Map(IEnumerable<Repository.AttractionsCategory> categories)
        {
            if (categories == null)
                return null;

            return from item in categories
                   select new Category
                   {
                       CategoryId = item.CategoryId,
                       CategoryName = item.CategoryName
                   };
        }

        internal static Category Map(Repository.AttractionsCategory category)
        {
            if (category == null)
                return null;
            return new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        internal static Location Map(Repository.AttractionsLocation location)
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

        //internal static Locale Map(Repository.Models.Locale locale)
        //{
        //    if (locale == null)
        //        return null;
        //    return new Locale
        //    {
        //        LocaleId = locale.LocaleId,
        //        LocaleName = locale.LocaleName
        //    };
        //}

        internal static Repository.AttractionsListing Map(Listing ContractListing)
        {
            throw new NotImplementedException();
        }

        internal static Listing Map(Repository.AttractionsListing listing)
        {
            if (listing == null)
                return null;

            return new Listing
                   {
                       ListingId = listing.ListingId,
                       Title = listing.Title,
                       ShortDescription = listing.ShortDescription,
                       LongDescription = listing.LongDescription,
                       //Locale = Map(listing.Locale),
                       UserRating = listing.UserRating,
                       Ranking = listing.Ranking,
                       PromoRank = listing.PromoRanking,
                       //Views = listing.Views,
                       Location = Map(listing.AttractionsLocation),
                       Category = Map(listing.AttractionsCategory),
                       UsageTypes = Map(listing.AttractionsUsageTypes)
                   };
        }
    }
}
