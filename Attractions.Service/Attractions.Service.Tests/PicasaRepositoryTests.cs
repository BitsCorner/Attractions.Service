using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Attractions.Repository;

namespace Attractions.Service.Tests
{
    [TestClass]
    public class PicasaRepositoryTests
    {
        [TestMethod, TestCategory("Integration")]
        public void PicasaRepository_UploadPhoto()
        {
            var r = new PicasaRepository();
            var photoid = r.AddPicture();
            Assert.IsNotNull(photoid);

        }

        [TestMethod, TestCategory("Integration")]
        public void FlickrRepository_GetPhotoInfo()
        {
            var r = new FlickrRepository();
            var photoid = r.GetPictures();
            Assert.IsNotNull(photoid);

        }

    }
}
