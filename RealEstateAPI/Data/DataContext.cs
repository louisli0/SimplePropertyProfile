using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateAPI.Domain;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) 
    : base(options)
    {}

    public DbSet<NSWVGData> NSWVGDatas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<NSWVGData>().HasNoKey();
        //modelBuilder.Entity<NSWVGData>().HasKey(vg => new { vg.DealingNumber, vg.PropertyId, vg.UnitNumber, vg.HouseNumber, vg.Purpose });
    }
}