using Service.IServices;

namespace Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCartService _shoppingCartService;

        public OrderService(IOrderRepository orderRepository, IShoppingCartService shoppingCartService)
        {
            _orderRepository = orderRepository;
            _shoppingCartService = shoppingCartService;
        }

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
