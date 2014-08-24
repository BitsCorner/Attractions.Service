using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Attractions.Repository.Models;

namespace Attractions.Repository
{
    public class AttractionsInitializer : DropCreateDatabaseIfModelChanges<AttractionsContext>
    {
        protected override void Seed(AttractionsContext context)
        {
            //var countries = new List<Country>
            //{
            //    new Country{CountryId=1,CountryName="Canada", LocaleId = 1033},
            //    new Country{CountryId=2,CountryName="United States", LocaleId = 1033},
            //};

            //countries.ForEach(s => context.Countries.Add(s));
            //context.SaveChanges();
        }
    }
}
