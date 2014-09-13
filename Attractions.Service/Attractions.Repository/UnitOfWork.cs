using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Repository
{
    public class UnitOfWork : IDisposable
    {
        private AttractionsEntities context = new AttractionsEntities();
        private GenericRepository<AttractionsCategory> categoryRepository;
        private GenericRepository<AttractionsListing> listingRepository;
        private GenericRepository<AttractionsUsageType> usageTypeRepository;

        public GenericRepository<AttractionsCategory> CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRepository<AttractionsCategory>(context);
                }
                return categoryRepository;
            }
        }
        public GenericRepository<AttractionsListing> ListingRepository
        {
            get
            {
                if (this.listingRepository == null)
                {
                    this.listingRepository = new GenericRepository<AttractionsListing>(context);
                }
                return listingRepository;
            }
        }
        public GenericRepository<AttractionsUsageType> UsageTypeRepository
        {
            get
            {
                if (this.usageTypeRepository == null)
                {
                    this.usageTypeRepository = new GenericRepository<AttractionsUsageType>(context);
                }
                return usageTypeRepository;
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
