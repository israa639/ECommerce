using Service.IServices;

namespace Service.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        readonly private IUserRepository _userReository = new UserRepository();
        readonly private IProductService _productService = new ProductService();
        readonly private IShoppingCartRepository _shoppingCartRepository = new ShoppingCartRepository();
        public void AddToCart(User user, int productId, int quantity)
        {

            if (user is null)
            { throw new ArgumentException("User not found."); }
            CheckUserQuantity(quantity);
            if (!_productService.HasSufficientStock(productId, quantity))
                throw new ArgumentException($"No enogh items are available in the stock");


            _shoppingCartRepository.AddItem(user, productId, quantity);
        }
        public void DeleteFromCart(User user, int productId)
        {
            _shoppingCartRepository.DeleteItem(user, productId);
        }
        public void UpdateCart(User user, int productId, int quantity)
        {
            _shoppingCartRepository.UpdateItem(user, productId, quantity);
        }
        private void CheckUserQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero.");
            }
        }
        public bool AreCartItemsInStock(ShoppingCart shoppingCart)
        {
            foreach (var item in shoppingCart.items.Values)
            {
                if (!_productService.HasSufficientStock(item.ProductId, item.Quantity))
                    return false;
            }
            return true;
        }
        public void UpdateStockQuantitiesAfterOrder(ShoppingCart shoppingCart)
        {
            foreach (var item in shoppingCart.items.Values)
            {
                _productService.UpdateProductQuantityInStock(item.ProductId, item.Quantity);

            }

        }

    }
}
