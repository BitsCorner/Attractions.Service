using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Repository
{
    public interface IGoogleRepository
    {
        //Task<IEnumerable<LocationPrediction>> GetLocations(string location);
        Task<AttractionsLocation> GetGooglePlacebyId(string PlaceId);


    }
}
