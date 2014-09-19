using Attractions.Processor;
using Attractions.Repository;
using BitsCorner.Logging;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Attractions.Service
{
    public static class UnityConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            
            container.RegisterType<IListingProcessor, ListingProcessor>();
            container.RegisterType<IGoogleRepository, GoogleRepository>();
            container.RegisterType<IHttpClientHelper, HttpClientHelper>();
            

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}