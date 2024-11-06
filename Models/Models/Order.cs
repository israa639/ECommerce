using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Domain.Models
{
    public class Order : BaseEntity<string>
    {





        public virtual IEnumerable<OrderItem> OrderItems { get; set; } = new LinkedList<OrderItem>();
        [Column(TypeName = "money")]
        public decimal TotalAmount { get; set; }

        public override string ToString()
        {
            StringBuilder orderDataString = new();
            orderDataString.Append($"Code:{Id} Date:{CreatedOn}  price:{TotalAmount} ");
            foreach (var item in OrderItems)
            {
                orderDataString.Append(item);
            }
            return orderDataString.ToString();
        }
    }
}
