

namespace Domain.Models
{
    public class CartItem
    {

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Decimal TotalPrice { get => CalculatePrice(); }


        private Decimal CalculatePrice()
        {
            Product product = null;
            DataStore.products.TryGetValue(ProductId, out product);
            return product is null ? 0 : Quantity * product.Price;
        }
        public override string ToString()
        {
            return $"Product id:{ProductId}  Quantity:{Quantity} TotalPrice:{TotalPrice}";
        }
    }
}
