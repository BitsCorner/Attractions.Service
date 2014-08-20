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
        [TestCategory("Unit")]
        public void GetAsync()
        {
            // Arrange
            var controller = new CountryController(null);

            // Act
            var result = controller.GetAsync();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            var controller = new CountryController(null);

            // Act
            var result = controller.GetAsync(5);

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            var controller = new CountryController(null);

            // Act
            controller.PostAsync(new Country() { 
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
            var controller = new CountryController(null);

            // Act
            controller.PutAsync(5, new Country {
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
            var controller = new CountryController(null);

            // Act
            controller.DeleteAsync(5);

            // Assert
        }
    }
}
