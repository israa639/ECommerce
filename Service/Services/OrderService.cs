using Repository.Repositories.cs;

namespace Service.Services
{
    public class OrderService
    {
        readonly private IOrderRepository _orderRepository = new OrderRepository();
        readonly private IProductRepository _productRepository = new ProductRepository();
        public void PlaceOrder(User user)
        {
            if (EnsureStockQuantity(user.ShoppingCart))
            {
                ShoppingCart shoppingCart = user.ShoppingCart.Copy();
                _orderRepository.PlaceOrder(user);
                UpdateStockQuantity(shoppingCart);
            }
            else
                throw new Exception("Can't place this order No enough Quantity available");
        }
        public bool EnsureStockQuantity(ShoppingCart shoppingCart)
        {
            foreach (var item in shoppingCart.items.Values)
            {
                if (!_productRepository.EnsureStockQuantity(item.ProductId, item.Quantity))
                    return false;
            }
            return true;
        }
        public void UpdateStockQuantity(ShoppingCart shoppingCart)
        {
            foreach (var item in shoppingCart.items.Values)
            {
                _productRepository.UpdateStockQuantityAfterOrder(item.ProductId, item.Quantity);

            }

        }


    }
}
