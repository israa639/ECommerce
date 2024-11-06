namespace Core.IRepositories
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public bool exists(int productId);

        public Product GetProductById(int productId);
        public void AddProduct(Product product);

        public void DeleteProduct(int productId);
        public void UpdateProduct(Product newProductData);

        public bool EnsureStockQuantity(int productId, int quantity);
        public bool UpdateStockQuantityAfterOrder(int productId, int quantity);



    }
}
