




namespace ECommerce
{
    internal static class ServiceCollectionExtensionMethods
    {


        public static ServiceCollection RegisterServices(this ServiceCollection services)
        {

            services.AddDbContext<AppDbContext>();// Options =>
            //{ Options.UseSqlServer("Data Source=.;Initial Catalog=Ecommerce;Integrated Security=True;TrustServerCertificate=True"); });


            services.AddSingleton(Log.Logger).AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<UserSignUpValidator>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<OrderManager>();
            services.AddScoped<ProductManager>();
            services.AddScoped<ShoppingCartManager>();
            services.AddScoped<UIManager>();



            return services;

        }
    }
}
