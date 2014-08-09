using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Attractions.Service;
using Attractions.Service.Controllers;
using Attractions.Repository.Models;

namespace Attractions.Service.Tests.Controllers
{
    [TestClass]
    public class CounrtyControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            CountyController controller = new CountyController();

            // Act
            IEnumerable<Country> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            CountyController controller = new CountyController();

            // Act
            Country result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            var controller = new CountyController();

            // Act
            controller.Post(new Country() { 
                    CountryId = 1,
                    CountryName ="Canada",
                    LocaleId = 1033 
                        }
                  );

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            var controller = new CountyController();

            // Act
            controller.Put(5, new Country {
                                    CountryId = 1,
                                    CountryName = "Canada",
                                    LocaleId = 1033 
                                    });

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            var controller = new CountyController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
