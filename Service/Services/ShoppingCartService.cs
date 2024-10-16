

namespace Service.Services
{
    public class ShoppingCartService
    {
        readonly private IUserRepository _userReository = new UserRepository();
        readonly private IShoppingCartRepository _shoppingCartRepository = new ShoppingCartRepository();
        public void AddToCart(User user, int productId, int quantity)
        {
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


    }
}
