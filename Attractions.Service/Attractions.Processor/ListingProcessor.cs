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
        public ListingProcessor(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ListingResponse>> GetAllListingsAsync()
        {
            var result = await unitOfWork.ListingRepository.GetAsync();
            //includeProperties: "Location,Category,Locale,UsageTypes,Status"
            return EntityMapper.Map(result);
        }

        public async Task<ListingResponse> InsertListingAsync(ListingRequest listing)
        {
            var contextListing = EntityMapper.Map(listing);
            try
            {
                await unitOfWork.ListingRepository.InsertAsync(contextListing);
                await unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
    }
}
