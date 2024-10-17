

namespace Domain.Models
{
    public class User
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public ShoppingCart ShoppingCart { get; } = new();
        public LinkedList<Order> Orders { get; } = new LinkedList<Order>();

        public override bool Equals(object obj)
        {
            if (obj is User other)
            {
                return this.UserID == other.UserID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return UserID.GetHashCode();
        }
        public Decimal MakeOrder()
        {
            if (!ShoppingCart.items.Any())
                throw new Exception("Cart is empty");

            Order newOrder = new Order() { UserID = this.UserID, OrderItems = ShoppingCart.items.Values, TotalAmount = ShoppingCart.CartTotalPrice() };
            ShoppingCart.ClearCart();
            Orders.AddFirst(newOrder);
            return newOrder.TotalAmount;

        }




    }
}
