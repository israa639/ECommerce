using Microsoft.Extensions.Configuration;






var serviceProvider = new ServiceCollection().RegisterServices().BuildServiceProvider();
var _UIManager = serviceProvider.GetRequiredService<UIManager>();
var config = new ConfigurationBuilder()
                .AddJsonFile("\\ECommerce\\ECommerce\\appsettings.json")
                .Build();

Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(config)
              .CreateLogger();




try
{
    Log.Information("Application Starting");

    _UIManager.Start();
}
catch (Exception ex)
{

    Log.Fatal(ex, "The application failed to start!");
}
finally
{
    Log.CloseAndFlush();
}







