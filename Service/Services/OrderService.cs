using Repository.Repositories.cs;
using Service.IServices;

namespace Service.Services
{
    public class OrderService : IOrderService
    {
        readonly private IOrderRepository _orderRepository = new OrderRepository();
        readonly private IShoppingCartService _shoppingCartService = new ShoppingCartService();
        public void PlaceOrder(User user)
        {
            if (_shoppingCartService.AreCartItemsInStock(user.ShoppingCart))
            {
                ShoppingCart shoppingCart = user.ShoppingCart.Copy();
                _orderRepository.PlaceOrder(user);
                _shoppingCartService.UpdateStockQuantitiesAfterOrder(shoppingCart);

            }
            else
            {
                user.ShoppingCart.ClearCart();
                throw new Exception("Can't place this order No enough Quantity available");


            }

        }



    }
}
