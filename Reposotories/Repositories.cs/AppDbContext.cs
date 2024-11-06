

using Microsoft.EntityFrameworkCore;
using Repository;

namespace Repositories
{
    public class AppDbContext : DbContext
    {



        public DbSet<User> Users { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public AppDbContext() : base(new DbContextOptions<AppDbContext>())
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<User>().HasOne(user => user.ShoppingCart).WithOne(cart => cart.user).
                HasForeignKey<ShoppingCart>(cart => cart.CreatedBy).
                OnDelete(DeleteBehavior.NoAction); ;
            builder.seedUsersAndShoppingCarts();
            builder.seedProducts();


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=.;Initial Catalog=Ecommerce;Integrated Security=True;TrustServerCertificate=True");
                    optionsBuilder.EnableSensitiveDataLogging();
                }
                base.OnConfiguring(optionsBuilder);
            }
        }












    }
}
