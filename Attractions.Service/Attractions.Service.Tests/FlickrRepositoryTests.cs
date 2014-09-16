using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Attractions.Repository;

namespace Attractions.Service.Tests
{
    [TestClass]
    public class FlickrRepositoryTests
    {
        [TestMethod, TestCategory("Integration")]
        public void FlickrRepository_UploadPhoto()
        {
            System.IO.Stream stream = new System.IO.FileStream("d:\\1.jpg",System.IO.FileMode.Open);
            string fileName = "Test.jsp";
            string title = "Integration Test Title";
            string description = "Integration Test Description Description Description Description Description";
            string tags = "Integration, Test, Repository, Flickr";
            bool isPublic = true;
            bool isFamily = false;
            bool isFriend = false;

            var r = new FlickrRepository();
            var photoid = r.AddPicture(stream, fileName, title, description, tags, isPublic, isFamily, isFriend);
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
