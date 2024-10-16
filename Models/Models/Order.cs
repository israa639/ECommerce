

namespace Domain.Models
{
    public class Order
    {
        public string OrderID { get; set; } = Guid.NewGuid().ToString();
        public string UserID { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;


        public IEnumerable<CartItem> OrderItems = new LinkedList<CartItem>();
        public decimal TotalAmount { get; set; }

        public override string ToString()
        {
            return $"Code:{OrderID} Date:{OrderDate}  price:{TotalAmount} ";
        }
    }
}
