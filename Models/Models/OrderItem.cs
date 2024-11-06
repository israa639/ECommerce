using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models
{
    public class OrderItem : BaseEntity<string>
    {


        public virtual Order? order { get; set; }
        [ForeignKey("product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual Product product { get; set; }
        [Column(TypeName = "money")]
        public Decimal TotalPrice { get; set; }

        public override string ToString()
        {
            return $"{ProductId} {Quantity} {product.Name} {TotalPrice}";
        }
    }
}