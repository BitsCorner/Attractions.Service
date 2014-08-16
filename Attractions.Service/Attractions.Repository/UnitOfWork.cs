using Attractions.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Repository
{
    public class UnitOfWork : IDisposable
    {
        private AttractionsContext context = new AttractionsContext();
        private GenericRepository<Country> countryRepository;
        private GenericRepository<State> stateRepository;
        private GenericRepository<City> cityRepository;
        private GenericRepository<Town> townRepository;
        private GenericRepository<Category> categoryRepository;
        private GenericRepository<Section> sectionRepository;
        private GenericRepository<Listing> listingRepository;

        public GenericRepository<Country> CountryRepository
        {
            get
            {
                if (this.countryRepository == null)
                {
                    this.countryRepository = new GenericRepository<Country>(context);
                }
                return countryRepository;
            }
        }

        public GenericRepository<State> StateRepository
        {
            get
            {
                if (this.stateRepository == null)
                {
                    this.stateRepository = new GenericRepository<State>(context);
                }
                return stateRepository;
            }
        }

        public GenericRepository<City> CityRepository
        {
            get
            {
                if (this.cityRepository == null)
                {
                    this.cityRepository = new GenericRepository<City>(context);
                }
                return cityRepository;
            }
        }

        public GenericRepository<Town> TownRepository
        {
            get
            {
                if (this.townRepository == null)
                {
                    this.townRepository = new GenericRepository<Town>(context);
                }
                return townRepository;
            }
        }

        public GenericRepository<Section> SectionRepository
        {
            get
            {
                if (this.sectionRepository == null)
                {
                    this.sectionRepository = new GenericRepository<Section>(context);
                }
                return sectionRepository;
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRepository<Category>(context);
                }
                return categoryRepository;
            }
        }

        public GenericRepository<Listing> ListingRepository
        {
            get
            {
                if (this.listingRepository == null)
                {
                    this.listingRepository = new GenericRepository<Listing>(context);
                }
                return listingRepository;
            }
        }

        public Task<int> SaveAsync()
        {
            return context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
