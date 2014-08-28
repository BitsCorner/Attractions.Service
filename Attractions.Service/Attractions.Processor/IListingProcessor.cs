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
        Task<IEnumerable<Listing>> GetAllListingsAsync();

        Task<Listing> GetListingByIdAsync(int id);

        Task<Listing> InsertListingAsync(Listing listing);

        Task<Listing> UpdateListingAsync(Listing listing);

        Task DeleteListingAsync(int id);
    }
}
