using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GlowShop.Models;

namespace GlowShop.Models
{
    public class GlowShopDbInitializer : DropCreateDatabaseIfModelChanges<GlowShopDbContext>
    {
        protected override void Seed(GlowShopDbContext context)
        {
            var categories = new List<Category>
            {
                new Category { Name = "Skincare", Description = "Luxury skin treatments and daily essentials.", ImageUrl = "/Content/images/categories/skincare.jpg" },
                new Category { Name = "Makeup", Description = "Premium cosmetics for every look.", ImageUrl = "/Content/images/categories/makeup.jpg" },
                new Category { Name = "Fragrance", Description = "Exclusive scents from top designers.", ImageUrl = "/Content/images/categories/fragrance.jpg" },
                new Category { Name = "Haircare", Description = "Professional products for healthy, glowing hair.", ImageUrl = "/Content/images/categories/haircare.jpg" }
            };

            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            var products = new List<Product>
            {
                // Skincare
                new Product { 
                    Name = "Radiance Serum", 
                    Description = "A potent vitamin C serum that brightens and evens skin tone for a luminous glow.", 
                    Price = 55.00m, 
                    SalePrice = 45.00m, 
                    Stock = 25, 
                    CategoryId = categories[0].Id, 
                    IsFeatured = true, 
                    Rating = 4.8m,
                    ImageUrl = "/Content/images/products/radiance_serum.png"
                },
                new Product { 
                    Name = "Night Repair Cream", 
                    Description = "Deep hydration and anti-aging overnight treatment to rejuvenate your skin while you sleep.", 
                    Price = 75.00m, 
                    Stock = 15, 
                    CategoryId = categories[0].Id, 
                    IsFeatured = true, 
                    Rating = 4.9m,
                    ImageUrl = "/Content/images/products/night_repair_cream.png"
                },
                new Product { 
                    Name = "Hydrating Cleanser", 
                    Description = "Gentle daily cleanser that removes impurities while maintaining skin's natural moisture.", 
                    Price = 32.00m, 
                    Stock = 40, 
                    CategoryId = categories[0].Id, 
                    IsFeatured = false, 
                    Rating = 4.7m,
                    ImageUrl = "/Content/images/products/hydrating_cleanser.png"
                },
                new Product { 
                    Name = "Deep Sea Mud Mask", 
                    Description = "Rich mineral-infused mud mask that detoxifies and minimizes the appearance of pores.", 
                    Price = 42.00m, 
                    SalePrice = 35.00m, 
                    Stock = 30, 
                    CategoryId = categories[0].Id, 
                    IsFeatured = false, 
                    Rating = 4.6m,
                    ImageUrl = "/Content/images/products/deep_sea_mud_mask.png"
                },
                // Makeup
                new Product { 
                    Name = "Velvet Matte Lipstick", 
                    Description = "Long-lasting, non-drying matte finish in 'Royal Red' for a sophisticated look.", 
                    Price = 28.00m, 
                    Stock = 50, 
                    CategoryId = categories[1].Id, 
                    IsFeatured = true, 
                    Rating = 4.7m,
                    ImageUrl = "/Content/images/products/velvet_matte_lipstick.png"
                },
                new Product { 
                    Name = "Long-Wear Foundation", 
                    Description = "Flawless medium-to-full coverage foundation with a natural skin-like finish.", 
                    Price = 48.00m, 
                    SalePrice = 38.00m, 
                    Stock = 30, 
                    CategoryId = categories[1].Id, 
                    IsFeatured = false, 
                    Rating = 4.6m,
                    ImageUrl = "/Content/images/products/long_wear_foundation.png"
                },
                new Product { 
                    Name = "Golden Glow Highlighter", 
                    Description = "Fine-milled champagne gold powder for a radiant, lit-from-within sparkle.", 
                    Price = 35.00m, 
                    Stock = 25, 
                    CategoryId = categories[1].Id, 
                    IsFeatured = true, 
                    Rating = 4.9m,
                    ImageUrl = "/Content/images/products/golden_glow_highlighter.png"
                },
                new Product { 
                    Name = "Volumizing Mascara", 
                    Description = "Intense black mascara that provides dramatic volume and length without clumping.", 
                    Price = 24.00m, 
                    Stock = 60, 
                    CategoryId = categories[1].Id, 
                    IsFeatured = false, 
                    Rating = 4.5m,
                    ImageUrl = "/Content/images/products/volumizing_mascara.png"
                },
                // Fragrance
                new Product { 
                    Name = "Midnight Rose Perfume", 
                    Description = "An enchanting blend of rare roses and warm amber for a mysterious fragrance.", 
                    Price = 120.00m, 
                    Stock = 10, 
                    CategoryId = categories[2].Id, 
                    IsFeatured = true, 
                    Rating = 5.0m,
                    ImageUrl = "/Content/images/products/midnight_rose_perfume.png"
                },
                // Haircare
                new Product { 
                    Name = "Silk Hair Serum", 
                    Description = "Weightless smoothing serum that tames frizz and adds a healthy shine to all hair types.", 
                    Price = 38.00m, 
                    Stock = 35, 
                    CategoryId = categories[3].Id, 
                    IsFeatured = true, 
                    Rating = 4.8m,
                    ImageUrl = "/Content/images/products/silk_hair_serum.png"
                }
            };

            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
