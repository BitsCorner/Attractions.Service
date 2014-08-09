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
            var countries = new List<Country>
            {
                new Country{CountryId=1,CountryName="Canada", LocaleId = 1033},
                new Country{CountryId=2,CountryName="United States", LocaleId = 1033},
            };

            var states = new List<State>
            {
                new State{
                    Country = new Country {CountryId=1,CountryName="Canada", LocaleId = 1033},
                    StateId = 1, StateName= "British Columbia", LocaleId = 1033 },
                new State{
                    Country = new Country {CountryId=1,CountryName="Canada", LocaleId = 1033},
                    StateId = 2, StateName= "Ontario", LocaleId = 1033 },
            };

            var cities = new List<City>
            {
                new City{
                    State = new State {StateId=1,StateName="British Columbia", LocaleId = 1033},
                    CityId = 1, CityName= "Vancouver", LocaleId = 1033 },
                new City{
                    State = new State {StateId=1,StateName="British Columbia", LocaleId = 1033},
                    CityId = 2, CityName= "Burnaby", LocaleId = 1033 }
            };

            countries.ForEach(s => context.Countries.Add(s));
            states.ForEach(s => context.States.Add(s));
            cities.ForEach(s => context.Cities.Add(s));

            context.SaveChanges();
        }
    }
}
