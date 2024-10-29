

namespace Service.IServices
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProduct(int productId);
        public bool HasSufficientStock(int productId, int quantity);
        public void UpdateProductQuantityInStock(int productId, int quantity);




    }
}




