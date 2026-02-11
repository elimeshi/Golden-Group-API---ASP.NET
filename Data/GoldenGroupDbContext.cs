using Microsoft.EntityFrameworkCore;
using GoldenGroupAPI.Models;

namespace GoldenGroupAPI.Data
{
    public class GoldenGroupDbContext : DbContext
    {
        public GoldenGroupDbContext(DbContextOptions<GoldenGroupDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<NormalListing> NormalListings { get; set; }
        public DbSet<TaboListing> TaboListings { get; set; }
        public DbSet<BuyerRequest> BuyerRequests { get; set; }
        public DbSet<NormalBuyerRequest> NormalBuyerRequests { get; set; }
        public DbSet<TaboBuyerRequest> TaboBuyerRequests { get; set; }
        public DbSet<HousingUnit> HousingUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure TPH (Table-per-Hierarchy) for Listing
            modelBuilder.Entity<Listing>()
                .HasDiscriminator<string>("ListingType")
                .HasValue<NormalListing>("Normal")
                .HasValue<TaboListing>("Tabo");

            // Configure TPH for BuyerRequest
            modelBuilder.Entity<BuyerRequest>()
                .HasDiscriminator<string>("RequestType")
                .HasValue<NormalBuyerRequest>("Normal")
                .HasValue<TaboBuyerRequest>("Tabo");

            // Relationships
            modelBuilder.Entity<Listing>()
                .HasOne(l => l.Client)
                .WithMany(c => c.Listings)
                .HasForeignKey(l => l.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BuyerRequest>()
                .HasOne(br => br.Client)
                .WithMany(c => c.BuyerRequests)
                .HasForeignKey(br => br.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HousingUnit>()
                .HasOne<Listing>()
                .WithMany(l => l.HousingUnits)
                .HasForeignKey(hu => hu.ListingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Enums as strings (optional but often preferred for readability)
            // or just let them be ints. 
            // For now, let's stick to default int behavior for simplicity 
            // unless requested otherwise.

            base.OnModelCreating(modelBuilder);
        }
    }
}
