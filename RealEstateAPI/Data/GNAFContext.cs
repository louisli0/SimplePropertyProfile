using Microsoft.EntityFrameworkCore;
using RealEstateAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAPI.Data
{
    public class GNAFContext: DbContext
    {
        public GNAFContext(DbContextOptions<GNAFContext> options) : base(options)
        {
        }

        public DbSet<GNAFLocalityDetails> GNAF_LocalityDetails { get; set; }
        public DbSet<GNAFStreetLocality> GNAF_StreetLocalityDetails { get; set; }
        public DbSet<GNAFAddressData> GNAF_AddressData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
