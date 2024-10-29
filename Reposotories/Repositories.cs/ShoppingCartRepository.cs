
namespace Repository.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        readonly IUserRepository _userRepository = new UserRepository();
        readonly IProductRepository _productRepository = new ProductRepository();

        public void AddItem(User user, int productId, int quantity)
        {
            Product productToBeAdded = _productRepository.GetProductById(productId);
            if (user is null)
            { throw new ArgumentException("User not found."); }
            CartItem newItem = new CartItem() { ProductId = productId, Quantity = quantity };
            user.ShoppingCart.InsertNewItem(newItem);
            _userRepository.Update(user.UserID, user);

        }
        public IEnumerable<CartItem> GetItems(User user)
        {

            if (user is null)
            { throw new ArgumentException("User not found."); }
            return user.ShoppingCart.items.Values;
        }
        public void DeleteItem(User user, int productId)
        {

            if (user is null)
            { throw new ArgumentException("User is not found."); }

            user.ShoppingCart.DeleteItem(productId);
            _userRepository.Update(user.UserID, user);

        }

        public void UpdateItem(User user, int productId, int quantity)
        {
            if (user is null)
            { throw new ArgumentException("User is not found."); }
            if (GetItemById(user, productId) is null)
            { throw new ArgumentException("item is not in you cart"); }

            DeleteItem(user, productId);
            AddItem(user, productId, quantity);
        }

        public CartItem GetItemById(User user, int productId)
        {
            return user.ShoppingCart.GetItem(productId);
        }
    }
}
