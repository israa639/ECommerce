



namespace Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetAllProducts()
        {
            return DataStore.products;
        }

        public Product GetProductById(int productId)
        {
            return DataStore.products.FirstOrDefault(p => p.ProductID == productId);


        }
        public void AddProduct(Product product)
        {
            if (GetProductById(product.ProductID) is not null)
                throw new Exception("product already exists");
            DataStore.products.Add(product);
        }
        public void DeleteProduct(int productId)
        {
            Product product = GetProductById(productId);
            if (product is null)
                throw new KeyNotFoundException("product is not found");
            DataStore.products.Remove(product);
        }
        public void UpdateProduct(int productId, Product newProductData)
        {
            DeleteProduct(productId);
            AddProduct(newProductData);
        }
        public bool EnsureStockQuantity(int productId, int quantity)
        {
            Product product = GetProductById(productId);
            return product is null ? false : product.StockQuantity >= quantity;
        }
        public bool UpdateStockQuantityAfterOrder(int productId, int quantity)
        {
            Product product = GetProductById(productId);
            if (product is null || product.StockQuantity - quantity < 0)
                return false;
            try
            {
                product.StockQuantity = product.StockQuantity - quantity;
                UpdateProduct(productId, product);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
