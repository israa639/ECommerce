using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories.cs;
using Service;


namespace ECommerce
{
    internal static class ServiceCollectionExtensionMethods
    {

        public static ServiceProvider RegisterServices(this ServiceCollection serviceCollection)
        {
            return serviceCollection.
                     AddScoped<IUserRepository, UserRepository>().
                     AddScoped<IShoppingCartRepository, ShoppingCartRepository>().
                     AddScoped<IProductRepository, ProductRepository>().
                     AddScoped<IOrderRepository, OrderRepository>().
                     AddScoped<UserSignUpValidator>().
                     AddScoped<IUserService, UserService>().
                     AddScoped<IShoppingCartService, ShoppingCartService>().
                     AddScoped<IProductService, ProductService>().
                     AddScoped<IOrderService, OrderService>().
                     AddScoped<OrderManager>().
                     AddScoped<ProductManager>().
                      AddScoped<ShoppingCartManager>().
                     AddScoped<UIManager>().
                     BuildServiceProvider();

        }
    }
}
