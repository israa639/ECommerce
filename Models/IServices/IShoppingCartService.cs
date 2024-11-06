namespace Core.IServices
{
    public interface IShoppingCartService
    {
        public void AddToCart(User user, int productId, int quantity);

        public void DeleteFromCart(User user, int productId);

        public void UpdateCart(User user, int productId, int quantity);
        public bool AreCartItemsInStock(ShoppingCart shoppingCart);
        public void UpdateStockQuantitiesAfterOrder(ShoppingCart shoppingCart);
        public void ClearCart(User user);
    }

}
