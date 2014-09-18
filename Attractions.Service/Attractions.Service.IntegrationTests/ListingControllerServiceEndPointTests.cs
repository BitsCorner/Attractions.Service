using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Attractions.Contracts;
using Attractions.Contracts.Requests;
using Attractions.Contracts.Responses;

namespace Attractions.Service.IntegrationTests
{
    [TestClass]
    public class ListingControllerServiceEndPointTests
    {
        private string serviceBaseUri = "http://localhost:9000/Api";
        private string ListingController_GetAsync_Uri = "/Listing";
        private string ListingController_PostAsync_Uri = "/Listing";

        [TestInitialize]
        public void Initialize()
        {
 
        }

        [TestMethod]
        public async Task ListingController_GetAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.serviceBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(ListingController_GetAsync_Uri);
                if (response.IsSuccessStatusCode)
                {
                    ListingRequest listing = await response.Content.ReadAsAsync<ListingRequest>();
                }
            }
        }

        public async Task ListingController_PostAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.serviceBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var lisitng = new ListingRequest() { ShortDescription = "", Title = "" };
                var response = await client.PostAsJsonAsync(ListingController_PostAsync_Uri, lisitng);
                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    Uri gizmoUrl = response.Headers.Location;
                }
            }
        }
    }
}
