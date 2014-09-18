using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Attractions.Repository;
using System.Threading.Tasks;

namespace Attractions.Service.Tests
{
    [TestClass]
    public class GoogleRepositoryTests
    {
        IHttpClientHelper httpClient;
        [TestInitialize]
        public void Initialize()
        {
            httpClient = new HttpClientHelper();
        }

        [TestMethod, TestCategory("Integration")]
        public async Task GoogleRepository_GetLocations()
        {
            var r = new GoogleRepository(httpClient);
            var location = "Coquitlam";
            var locations = await r.GetLocations(location);
            Assert.IsNotNull(locations);
        }

    }
}
