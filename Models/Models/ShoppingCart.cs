
namespace Domain.Models
{
    public class ShoppingCart
    {
        public string cartId { get; set; }
        public string userId { get; set; }
        public LinkedList<CartItem> items { get; set; } = new LinkedList<CartItem>();

        public void InsertNewItem(CartItem newItem)
        {
            if (newItem is null)
                throw new ArgumentException("item shouldn't be null");
            CartItem item = GetItem(newItem.ProductId);
            if (item is not null)
            {
                UpdateItem(item.ProductId, newItem.Quantity + item.Quantity);
            }
            else
            {
                items.AddFirst(newItem);
            }
        }

        public CartItem GetItem(int ProductId)
        {
            CartItem item = items.FirstOrDefault(i => i.ProductId == ProductId);


            return item;
        }

        public void DeleteItem(int ProductId)
        {
            CartItem itemToBeDeleted = GetItem(ProductId);
            if (itemToBeDeleted is null)
                throw new ArgumentNullException(" product is not found");
            items.Remove(itemToBeDeleted);
        }

        public void UpdateItem(int productId, int quantity)
        {
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
            foreach (var item in items)
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
            return new ShoppingCart() { userId = userId, cartId = cartId, items = new LinkedList<CartItem>(items) };
        }


    }
}
