using Microsoft.EntityFrameworkCore;
using nature_hub_server.Models;

namespace nature_hub_server.Data
{
    public partial class NatureHubDbContext:DbContext
    {
        public NatureHubDbContext(DbContextOptions<NatureHubDbContext> options) : base(options)
        {

        }
        public DbSet<HealthTip> HealthTips { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Remedy> Remedies { get; set; }
        public DbSet<CartItem> Carts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
