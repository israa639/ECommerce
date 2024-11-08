namespace Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        readonly IUserRepository _userRepository;
        readonly IProductRepository _productRepository;
        AppDbContext _dbContext;


        public ShoppingCartRepository(IUserRepository userRepository, IProductRepository productRepository, AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public void AddItem(User user, int productId, int quantity)
        {
            Product productToBeAdded = _productRepository.GetProductById(productId);
            if (user is null)
            { throw new ArgumentException("User not found."); }
            CartItem newItem = new CartItem() { Id = Guid.NewGuid().ToString(), ProductId = productId, Quantity = quantity, CreatedBy = user.Id, CreatedOn = DateTime.Now, unitPrice = productToBeAdded.Price };

            user.ShoppingCart.InsertNewItem(newItem);
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();

        }
        public IEnumerable<CartItem> GetItems(User user)
        {

            if (user is null)
            { throw new ArgumentException("User not found."); }
            return user.ShoppingCart.items;
        }
        public void DeleteItem(User user, int productId)
        {

            if (user is null)
            { throw new ArgumentException("User is not found."); }
            CartItem item = GetItemById(user, productId);

            _dbContext.Remove(item);

            _dbContext.SaveChanges();

        }

        public void UpdateItem(User user, int productId, int quantity)
        {
            if (user is null)
            { throw new ArgumentException("User is not found."); }
            if (GetItemById(user, productId) is null)
            { throw new ArgumentException("item is not in you cart"); }
            user.ShoppingCart.UpdateItem(productId, quantity);
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();

        }

        public CartItem GetItemById(User user, int productId)
        {
            return user.ShoppingCart.GetItem(productId);
        }
        public void ClearCart(User user)
        {
            user.ShoppingCart.ClearCart();
            _userRepository.Update(user);

        }
    }
}
