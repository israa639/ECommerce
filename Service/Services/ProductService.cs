using Service.IServices;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository = new ProductRepository();
        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();

        }
        public Product GetProduct(int productId)
        {
            Product product = _productRepository.GetProductById(productId);
            if (product is null)
                throw new ArgumentException("product doesnot exist");
            return product;

        }
        public bool HasSufficientStock(int productId, int quantity)
        {
            Product product = GetProduct(productId);
            if (!_productRepository.EnsureStockQuantity(productId, quantity))
                return false;
            return true;

        }
        public void UpdateProductQuantityInStock(int productId, int quantity)
        {
            _productRepository.UpdateStockQuantityAfterOrder(productId, quantity);
        }



    }
}
