using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Attractions.Repository;

namespace Attractions.Service.Tests
{
    [TestClass]
    public class PicasaRepositoryTests
    {
        IHttpClientHelper httpClient;
        [TestInitialize]
        public void Initialize()
        {
            httpClient = new HttpClientHelper();
        }

        [TestMethod, TestCategory("Integration")]
        public void PicasaRepository_UploadPhoto()
        {
            var r = new PicasaRepository(httpClient);
            var photoid = r.AddPicture();
            Assert.IsNotNull(photoid);

        }

        [TestMethod, TestCategory("Integration")]
        public void FlickrRepository_GetPictures()
        {

            var r = new PicasaRepository(httpClient);
            var photoid = r.GetPictures();
            Assert.IsNotNull(photoid);

        }

    }
}
