using Attractions.Contracts.Requests;
using Attractions.Contracts.Responses;
using Attractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Processor
{
    public interface IListingProcessor
    {
        Task<IEnumerable<ListingResponse>> GetAllListingsAsync();

        Task<ListingResponse> InsertListingAsync(ListingRequest listing);

        Task<IEnumerable<CategoryResponse>> GetCategoriesAsync();

        Task<IEnumerable<UsageTypeResponse>> GetUsageTypesAsync();
    }
}
