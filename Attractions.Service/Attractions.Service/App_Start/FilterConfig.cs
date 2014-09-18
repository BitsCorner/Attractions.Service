using Attractions.Service.Filters;
using System.Web;
using System.Web.Http.Filters;

namespace Attractions.Service
{
    public class FilterConfig
    {
        public static void RegisterWebApiFilters(HttpFilterCollection filters)
        {
            filters.Add(new ValidationFilter());
            //filters.Add(new ExceptionFilter());
        }

    }
}