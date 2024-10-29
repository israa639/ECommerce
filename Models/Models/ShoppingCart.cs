
namespace Domain.Models
{
    public class ShoppingCart
    {
        public string cartId { get; set; }
        public string userId { get; set; }
        public Dictionary<int, CartItem> items { get; set; } = new Dictionary<int, CartItem>();

        public void InsertNewItem(CartItem newItem)
        {
            if (newItem is null)
                throw new ArgumentNullException("item shouldn't be null");
            CartItem item = GetItem(newItem.ProductId);
            if (item is not null)
            {
                UpdateItem(item.ProductId, newItem.Quantity + item.Quantity);
            }
            else
            {
                items.Add(newItem.ProductId, newItem);
            }
        }

        public CartItem GetItem(int ProductId)
        {
            CartItem item = null;
            items.TryGetValue(ProductId, out item);
            return item;
        }

        public void DeleteItem(int ProductId)
        {

            if (!items.ContainsKey(ProductId))
                throw new InvalidOperationException(" product is not found in your cart");
            items.Remove(ProductId);
        }

        public void UpdateItem(int productId, int quantity)
        {
            if (!items.ContainsKey(productId))
                throw new InvalidOperationException(" product is not found in your cart");
            DeleteItem(productId);
            InsertNewItem(new CartItem() { ProductId = productId, Quantity = quantity });
        }

        public void ClearCart()
        {
            this.items.Clear();
        }
        public decimal CartTotalPrice()
        {
            decimal totalPrice = 0.0m;
            foreach (var item in items.Values)
            {
                totalPrice += item.TotalPrice;
            }
            return totalPrice;
        }
        public bool HasNoItems()
        {
            return !items.Any();
        }
        public override bool Equals(object obj)
        {
            if (obj is ShoppingCart other)
            {
                return this.cartId == other.cartId;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return cartId.GetHashCode();
        }
        public ShoppingCart Copy()
        {
            return new ShoppingCart() { userId = userId, cartId = cartId, items = new Dictionary<int, CartItem>(items) };
        }


    }
}
