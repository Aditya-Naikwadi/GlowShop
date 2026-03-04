using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GlowShop.Models
{
    public class GlowShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public GlowShopDbContext()
            : base("GlowShopContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new GlowShopDbInitializer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        public static GlowShopDbContext Create()
        {
            return new GlowShopDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOptional(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId);

            // Ensure SQL Server provider sees decimal with precision and scale
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.SalePrice)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);
        }
    }
}
