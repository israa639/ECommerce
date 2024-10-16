namespace Domain.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is Product other)
            {
                return this.ProductID == other.ProductID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ProductID.GetHashCode();
        }
        public override string ToString()
        {
            return $"id:{ProductID}  Name:{Name} Description:{Description} Price:{Price}  StockQuantity:{StockQuantity}";
        }
    }
}



