



namespace Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetAllProducts()
        {
            return DataStore.products.Values;
        }

        public Product GetProductById(int productId)
        {
            Product product = null;
            DataStore.products.TryGetValue(productId, out product);
            return product;


        }
        public void AddProduct(Product product)
        {
            if (GetProductById(product.ProductID) is not null)
                throw new Exception("product already exists");
            DataStore.products.Add(product.ProductID, product);
        }
        public void DeleteProduct(int productId)
        {

            if (!DataStore.products.ContainsKey(productId))
                throw new ArgumentNullException(" product is not found");
            DataStore.products.Remove(productId);
        }
        public void UpdateProduct(int productId, Product newProductData)
        {
            if (!DataStore.products.ContainsKey(productId))
                throw new ArgumentNullException(" product is not found");
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
