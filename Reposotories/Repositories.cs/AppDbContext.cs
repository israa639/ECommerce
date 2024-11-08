

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository;
using Serilog;

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
                OnDelete(DeleteBehavior.NoAction);
            builder.Entity<User>().HasMany(user => user.Orders).WithOne(order => order.user).HasForeignKey(order => order.CreatedBy).
              OnDelete(DeleteBehavior.NoAction);

            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .HasDatabaseName("IX_User_Email");
            builder.Entity<User>()
                .HasIndex(u => u.UserName)
                .HasDatabaseName("IX_User_UserName");

            builder.seedUsersAndShoppingCarts();
            builder.seedProducts();


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=.;Initial Catalog=Ecommerce;Integrated Security=True;TrustServerCertificate=True");
                    optionsBuilder.EnableSensitiveDataLogging().
                        LogTo(Log.Information, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Debug);
                }
                base.OnConfiguring(optionsBuilder);
            }
        }












    }
}
