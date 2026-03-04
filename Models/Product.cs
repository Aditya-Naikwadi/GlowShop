using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlowShop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }

        [Required, Column(TypeName = "decimal")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal")]
        [Display(Name = "Sale Price")]
        public decimal? SalePrice { get; set; }

        [Display(Name = "Stock Quantity")]
        public int Stock { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = "Featured Product")]
        public bool IsFeatured { get; set; }

        [Range(0, 5)]
        public decimal Rating { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Computed helper
        public bool IsOnSale => SalePrice.HasValue && SalePrice < Price;
        public decimal DisplayPrice => IsOnSale ? SalePrice.Value : Price;
    }

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public class ContactMessage
    {
        [Key]
        public int MessageId { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [StringLength(300)]
        public string Subject { get; set; }

        [Required, StringLength(2000)]
        public string Message { get; set; }

        public DateTime SentAt { get; set; } = DateTime.Now;
        public bool IsRead { get; set; }
    }
}
