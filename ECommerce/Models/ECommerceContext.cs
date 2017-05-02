using Microsoft.EntityFrameworkCore;
 
namespace ECommerce.Models
{
    public class ECommerceContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get; set; }
    }
}