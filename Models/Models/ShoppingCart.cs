namespace Core.Domain.Models
{
    public class ShoppingCart : BaseEntity<string>
    {


        public virtual User user { get; set; }
        public virtual LinkedList<CartItem> items { get; set; } = new LinkedList<CartItem>();

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
                items.AddLast(newItem);
            }
        }

        public CartItem GetItem(int ProductId)
        {
            return items.FirstOrDefault(item => item.ProductId == ProductId);
        }

        public void DeleteItem(int ProductId)
        {
            CartItem itemToBeRemoved = items.FirstOrDefault(item => item.ProductId == ProductId);
            if (itemToBeRemoved is null)
                throw new InvalidOperationException(" product is not found in your cart");
            items.Remove(itemToBeRemoved);
        }

        public void UpdateItem(int productId, int quantity)
        {
            CartItem itemToBeUpdated = items.FirstOrDefault(item => item.ProductId == productId);
            if (itemToBeUpdated is null)
                throw new InvalidOperationException(" product is not found in your cart");
            DeleteItem(productId);
            InsertNewItem(new CartItem()
            {
                Id = itemToBeUpdated.Id,
                ProductId = productId,
                Quantity = quantity,
                CreatedBy = itemToBeUpdated.CreatedBy,
                CreatedOn = itemToBeUpdated.CreatedOn,
                UpdatedOn = DateTime.Now,
                UpdatedBy = user.Id
            });
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
                return this.Id == other.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public ShoppingCart Copy()
        {
            return new ShoppingCart() { CreatedBy = CreatedBy, Id = Id, items = new LinkedList<CartItem>(items) };
        }


        public IEnumerable<OrderItem> ToOrderItems()
        {
            LinkedList<OrderItem> orderItems = new();
            foreach (var item in this.items)
            {
                OrderItem orderItem = item;
                orderItems.AddLast(orderItem);
            }
            return orderItems;
        }


    }
}
