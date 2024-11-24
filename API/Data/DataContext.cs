using API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace API.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<AppUser> Felhasznalok { get; set; }
        public DbSet<Role> Szerepek { get; set; }
        public DbSet<Product> Aruk { get; set; }
        public DbSet<Warehouse> Telephelyek { get; set; }
        public DbSet<Stock> Keszlet { get; set; }
        public DbSet<Logistic> Mozgatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Product>()
         .Property(o => o.Id)
         .ValueGeneratedOnAdd()
         .UseMySqlIdentityColumn();

            // Stock: kompozit kulcs
            modelBuilder.Entity<Stock>()
                .HasKey(k => new { k.ProductId, k.WarehouseId });

            // Stock kapcsolatok: Product
            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Product)
                .WithMany(p => p.Stocks) // Több Stock egy Producthoz
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Stock kapcsolatok: Warehouse
            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Warehouse)
                .WithMany(w => w.Stocks) // Több Stock egy Warehouse-hoz
                .HasForeignKey(s => s.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Logistic: kompozit kulcs
            modelBuilder.Entity<Logistic>()
                .HasKey(m => new { m.SourceId, m.DestinationId, m.ProductId, m.Date });

            // Logistic kapcsolatok
            modelBuilder.Entity<Logistic>()
                .HasOne(l => l.Source)
                .WithMany(w => w.SourceLogistics)
                .HasForeignKey(l => l.SourceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Logistic>()
                .HasOne(l => l.Destination)
                .WithMany(w => w.DestinationLogistics)
                .HasForeignKey(l => l.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Logistic>()
                .HasOne(l => l.Product)
                .WithMany(p => p.Logistics)
                .HasForeignKey(l => l.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // AppUser és Role kapcsolata
            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    
}
