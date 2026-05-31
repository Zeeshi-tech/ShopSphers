using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopSphere.Models;

namespace ShopSphere.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SellerRequest> SellerRequests { get; set; }

        // NOTE: Cart is now session-based, no CartItems DbSet needed
        // If you have old CartItems table, it won't cause errors if not used

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Entity<Product>().Property(p => p.OriginalPrice).HasColumnType("decimal(18,2)");
            builder.Entity<Order>().Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");
            builder.Entity<OrderItem>().Property(o => o.Price).HasColumnType("decimal(18,2)");

            builder.Entity<OrderItem>()
                .HasOne(o => o.Order).WithMany(o => o.OrderItems)
                .HasForeignKey(o => o.OrderId).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderItem>()
                .HasOne(o => o.Product).WithMany()
                .HasForeignKey(o => o.ProductId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
