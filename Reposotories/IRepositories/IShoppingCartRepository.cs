

namespace Repository.IRepositories
{
    public interface IShoppingCartRepository
    {
        public IEnumerable<CartItem> GetItems(User user);
        public void AddItem(User user, int productId, int quantity);
        public void DeleteItem(User user, int productId);
        public void UpdateItem(User user, int productId, int quantity);
        public CartItem GetItemById(User user, int productId);

    }
}
