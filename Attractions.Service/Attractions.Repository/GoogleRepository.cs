using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Attractions.Contracts;
using Attractions.Contracts.Responses;
using Attractions.Contracts.Requests;
using Attractions.Repository.Entities;
namespace Attractions.Repository
{
    public class GoogleRepository : IGoogleRepository
    {
        IHttpClientHelper httpClient;
        public GoogleRepository(IHttpClientHelper httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<LocationPredictionRequest>> GetLocations(string location)
        {
            var url = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input=" + location + "&types=(cities)&key=" + "AIzaSyCmRdR33uhc0Bd7V_RkDu3q2xXwb1Tjmms";
            var result = await this.httpClient.CallHttpClientGet(url);
            var content = await result.Content.ReadAsStringAsync();
            try
            {
                var locations = JsonConvert.DeserializeObject<Predictions>(content);
                return locations.predictions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AttractionsLocation> GetGooglePlacebyId(string PlaceId)
        {
            var url = string.Format("https://maps.googleapis.com/maps/api/place/details/json?placeid={0}&key={1}", PlaceId , "AIzaSyCmRdR33uhc0Bd7V_RkDu3q2xXwb1Tjmms");
            var result = await this.httpClient.CallHttpClientGet(url);
            var content = await result.Content.ReadAsStringAsync();
            try
            {
                var locations = JsonConvert.DeserializeObject<LocationSearchResult>(content);
                return locations.result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
