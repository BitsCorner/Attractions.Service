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
        private GenericRepository<Category> categoryRepository;
        private GenericRepository<Listing> listingRepository;

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
