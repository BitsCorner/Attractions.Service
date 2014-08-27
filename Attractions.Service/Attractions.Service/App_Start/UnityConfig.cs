using Attractions.Processor;
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
            
            container.RegisterType<ILogger, Logger>(new HierarchicalLifetimeManager());
            container.RegisterType<IListingProcessor, ListingProcessor>();

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}