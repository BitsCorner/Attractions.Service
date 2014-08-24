using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;
using Attractions.Repository.Models;

namespace Attractions.Repository
{
    public class AttractionsContext : DbContext
    {
        public AttractionsContext() : base("AttractionsContext")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Listing> Listings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
