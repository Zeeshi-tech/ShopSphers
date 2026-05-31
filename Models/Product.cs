using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopSphere.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        // CATEGORY STRING (for filtering)
        public string Category { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        // ORIGINAL PRICE (for discount display)
        [Column(TypeName = "decimal(18,2)")]
        public decimal OriginalPrice { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public bool IsApproved { get; set; } = true;

        public string SellerName { get; set; } = "Admin";

        // STOCK
        public int Stock { get; set; } = 100;

        // RATING
        public double Rating { get; set; } = 4.5;

        // IMAGE UPLOAD
        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        // REVIEWS
        public List<Review> Reviews { get; set; } = new();
    }
}