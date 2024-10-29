

using ECommerce;
using Microsoft.Extensions.DependencyInjection;
var serviceProvider = new ServiceCollection().RegisterServices();

var _UIManager = serviceProvider.GetRequiredService<UIManager>();

_UIManager.Start();

