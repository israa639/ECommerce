

namespace Domain.Models
{
    public class CartItem
    {

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Decimal TotalPrice { get => CalculatePrice(); }


        private Decimal CalculatePrice()
        {
            Product product = DataStore.products.FirstOrDefault(p => p.ProductID == this.ProductId);
            return product is null ? 0 : Quantity * product.Price;
        }
        public override string ToString()
        {
            return $"Product id:{ProductId}  Quantity:{Quantity} TotalPrice:{TotalPrice}";
        }
    }
}
