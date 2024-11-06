using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Models
{
    public class Product : BaseEntity<int>
    {

        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is Product other)
            {
                return this.Id == other.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override string ToString()
        {
            return $"id:{Id}  Name:{Name} Description:{Description} Price:{Price}  StockQuantity:{StockQuantity}";
        }
    }
}



