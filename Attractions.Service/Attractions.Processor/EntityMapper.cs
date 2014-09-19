using Attractions.Contracts;
using Attractions.Contracts.Requests;
using Attractions.Contracts.Responses;
using Attractions.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Processor
{
    internal class EntityMapper
    {

        internal static AttractionsListing Map(ListingRequest listing)
        {
            if (listing == null)
                return null;

            return new AttractionsListing
                   {
                       Title = listing.Title,
                       ShortDescription = listing.ShortDescription,
                       LongDescription = listing.LongDescription,
                       //Locale = Map(item.Locale),
                       //UserRating = item.UserRating,
                       //Ranking = item.Ranking,
                       //PromoRank = item.PromoRanking,
                       //Views = item.Views,
                       CategoryId = listing.CategoryId
                   };
        }

        internal static IEnumerable<ListingResponse> Map(IEnumerable<AttractionsListing> listings)
        {
            if (listings == null)
                return null;

            return from item in listings
                   select new ListingResponse
                   {
                       ListingId = item.ListingId,
                       Title = item.Title,
                       ShortDescription = item.ShortDescription,
                       LongDescription = item.LongDescription,
                       UserRating = item.UserRating,
                       Ranking = item.Ranking,
                       Location = Map(item.AttractionsLocation),
                       Category = Map(item.AttractionsCategory),
                       //PromoRank = item.PromoRank,
                       //Views = item.Views,
                       //Location = item.Location,
                       //Category = item.Category
                   };
        }

        private static CategoryResponse Map(AttractionsCategory attractionsCategory)
        {
            if (attractionsCategory == null)
                return null;

            return new CategoryResponse
            {
                CategoryId = attractionsCategory.CategoryId,
                CategoryName = attractionsCategory.CategoryName
            };
        }

        private static LocationResponse Map(AttractionsLocation attractionsLocation)
        {
            if (attractionsLocation == null)
                return null;

            return new LocationResponse
            {
                LocationId = attractionsLocation.LocationId,
                GooglePlaceId = attractionsLocation.place_id,
                Name = attractionsLocation.name,
                Address = attractionsLocation.formatted_address,
                Url = attractionsLocation.url
            };
        }

        internal static ListingResponse Map(AttractionsListing item)
        {
            if (item == null)
                return null;

            return new ListingResponse
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
                       //Location = item.Location,
                       //Category = item.Category
                   };
        }


        internal static IEnumerable<UsageTypeResponse> Map(IEnumerable<Repository.AttractionsUsageType> usageTypes)
        {
            if (usageTypes == null)
                return null;

            return from item in usageTypes
                   select new UsageTypeResponse
                   {
                        UsageTypeName = item.UsageTypeName,
                        UsageTypeId = item.UsageTypeId
                   };
        }

        internal static IEnumerable<CategoryResponse> Map(IEnumerable<Repository.AttractionsCategory> categories)
        {
            if (categories == null)
                return null;

            return from item in categories
                   select new CategoryResponse
                   {
                       CategoryId = item.CategoryId,
                       CategoryName = item.CategoryName
                   };
        }

        //internal static Category Map(Category category)
        //{
        //    if (category == null)
        //        return null;
        //    return new Category
        //    {
        //        CategoryId = category.CategoryId,
        //        CategoryName = category.CategoryName
        //    };
        //}

        //internal static Location Map(Repository.AttractionsLocation location)
        //{
        //    if (location == null)
        //        return null;
        //    return new Location
        //    {
        //        LocationId = location.LocationId,
        //        place_id = location.place_id,
        //        short_name = location.short_name,
        //        long_name = location.long_name
        //    };
        //}

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

    }
}
