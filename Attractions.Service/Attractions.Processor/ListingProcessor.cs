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
    public class ListingProcessor : IListingProcessor
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();
        protected IGoogleRepository googleRepository;

        public ListingProcessor(UnitOfWork unitOfWork, IGoogleRepository googleRepository)
        {
            this.unitOfWork = unitOfWork;
            this.googleRepository = googleRepository;
        }

        #region Public Members
        public async Task<IEnumerable<ListingResponse>> GetAllListingsAsync()
        {
            var result = await unitOfWork.ListingRepository.GetAsync();
            return EntityMapper.Map(result);
        }

        public async Task<ListingResponse> GetListingByIdAsync(int listingId)
        {
            var result = await unitOfWork.ListingRepository.GetByIDAsync(listingId);
            return EntityMapper.Map(result);
        }

        public async Task<ListingResponse> InsertListingAsync(ListingRequest listing)
        {
            var LocationId  = await CreateLocation(listing.PlaceId);

            var contextListing = EntityMapper.Map(listing);
            contextListing.LocationId = LocationId;
           
            await unitOfWork.ListingRepository.InsertAsync(contextListing);
            await unitOfWork.SaveAsync();

            return EntityMapper.Map(contextListing);
        }

        public async Task<IEnumerable<CategoryResponse>> GetCategoriesAsync()
        {
            var result = await unitOfWork.CategoryRepository.GetAsync();
            return EntityMapper.Map(result);
        }

        public async Task<IEnumerable<UsageTypeResponse>> GetUsageTypesAsync()
        {
            var result = await unitOfWork.UsageTypeRepository.GetAsync();
            return EntityMapper.Map(result);
        }

        #endregion

        #region Private Members
        private async Task<int> CreateLocation(string PlaceId)
        {
            var result = await unitOfWork.LocationRepository.GetAsync(filter: m => m.place_id == PlaceId);
            var location = result.FirstOrDefault();
            if (location != null)
                return location.LocationId;
            else
            {

                var newLocation = await GetNewLocationInfo(PlaceId);
                await unitOfWork.LocationRepository.InsertAsync(newLocation);
                await unitOfWork.SaveAsync();
                return newLocation.LocationId;
            }
        }

        private async Task<AttractionsLocation> GetNewLocationInfo(string PlaceId)
        {
            var location = await googleRepository.GetGooglePlacebyId(PlaceId);
            if (location == null)
                return null;
            else
                return location;
        }

        #endregion

    }
}
