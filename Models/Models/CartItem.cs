using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models
{
    public class CartItem : BaseEntity<string>
    {

        [ForeignKey("cart")]
        public string CartId { get; set; }

        public virtual ShoppingCart cart { get; set; }
        [ForeignKey("product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "money")]
        public decimal unitPrice { get; set; }
        public virtual Product product { get; set; }
        [Column(TypeName = "money")]
        public Decimal TotalPrice { get => Quantity * unitPrice; }


        public static implicit operator OrderItem(CartItem item)
        {
            return new OrderItem()
            {
                Id = item.Id,
                CreatedBy = item.CreatedBy,
                CreatedOn = item.CreatedOn,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                TotalPrice = item.TotalPrice
            };
        }

        public override string ToString()
        {
            return $"Product id:{ProductId}  Quantity:{Quantity} TotalPrice:{TotalPrice}";
        }
    }
}
