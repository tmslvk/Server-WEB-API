using Microsoft.EntityFrameworkCore;
using serverSobesedovanie.Models;

namespace serverSobesedovanie
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Fridge> Fridges { get; set; } = null!;
        public DbSet<FridgeModel> FridgeModels { get; set; } = null!;
        public DbSet<FridgeProduct> FridgeProducts { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { 
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fridge
            modelBuilder.Entity<Fridge>().HasKey(f => f.Id);
            modelBuilder.Entity<Fridge>().HasOne(f => f.FridgeModel).WithOne(fm => fm.Fridge).HasForeignKey<Fridge>(f => f.ModelId);

            //Products
            modelBuilder.Entity<Product>().HasKey(p => p.Id);

            //FridgeModel
            modelBuilder.Entity<FridgeModel>().HasKey(fm => fm.Id);
            

            //FridgeProducts
            modelBuilder.Entity<FridgeProduct>().HasKey(fp => fp.Id);
            modelBuilder.Entity<FridgeProduct>().HasOne(fp => fp.Product).WithMany(p => p.FridgeProducts).HasForeignKey(fp=>fp.ProductId);
            modelBuilder.Entity<FridgeProduct>().HasOne(fp => fp.Fridge).WithMany(f=>f.FridgeProducts).HasForeignKey(fp => fp.FridgeId);
        }
    }
}
