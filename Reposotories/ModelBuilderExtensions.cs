using Microsoft.EntityFrameworkCore;

namespace Repository
{
    internal static class ModelBuilderExtensions
    {

        public static void seedUsersAndShoppingCarts(this ModelBuilder builder)
        {


            LinkedList<User> users = new();
            LinkedList<ShoppingCart> shoppingCarts = new();

            for (int i = 0; i < 5000; i++)
            {
                string userId = Guid.NewGuid().ToString();
                DateTime time = DateTime.Now;

                User user = new User()
                {
                    Id = userId,
                    CreatedBy = userId,
                    CreatedOn = time,
                    UserName = $"israa{i}",
                    Password = "123456789",
                    Address = "cairo,egypt",
                    Email = $"israa{i}@gmail.com",
                };
                ShoppingCart cart = new()
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedBy = user.Id,
                    CreatedOn = time

                };
                users.AddFirst(user);
                shoppingCarts.AddFirst(cart);
            }
            builder.Entity<User>().HasData(users);
            builder.Entity<ShoppingCart>().HasData(shoppingCarts);
        }
        public static void seedProducts(this ModelBuilder builder)
        {

            LinkedList<Product> products = new();
            for (int i = 1; i < 500; i++)
            {
                string id = "0057bbd5-7589-4c29-bf22-21c725bbdf57";

                products.AddFirst(new Product()
                {
                    Id = i,
                    CreatedBy = id,
                    CreatedOn = DateTime.Now,
                    Description = "best rolex watch",
                    Price = 2000.00m,
                    Name = $"Rolex{i}",
                    StockQuantity = 10


                });
            }
            builder.Entity<Product>().HasData(products);

        }

    }
}
