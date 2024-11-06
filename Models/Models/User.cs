namespace Core.Domain.Models
{
    public class User : BaseEntity<String>
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public String Address { get; set; }
        // [ForeignKey("ShoppingCart")]
        // public string? ShoppingCartId { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; } = default;
        public virtual LinkedList<Order> Orders { get; } = new LinkedList<Order>();

        public override bool Equals(object obj)
        {
            if (obj is User other)
            {
                return this.Id == other.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public Decimal MakeOrder()
        {
            if (!ShoppingCart.items.Any())
                throw new Exception("Cart is empty");

            Order newOrder = new Order() { Id = Guid.NewGuid().ToString(), OrderItems = ShoppingCart.ToOrderItems(), TotalAmount = ShoppingCart.CartTotalPrice(), CreatedBy = this.Id, CreatedOn = DateTime.Now };
            ShoppingCart.ClearCart();
            Orders.AddFirst(newOrder);
            return newOrder.TotalAmount;

        }




    }
}
