namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool exists(int productId)
        {
            return _dbContext.Products.Any(p => p.Id == productId);
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Products;
        }

        public Product GetProductById(int productId)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Id == productId);


        }
        public void AddProduct(Product product)
        {
            if (exists(product.Id))
                throw new Exception("product already exists");
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }
        public void DeleteProduct(int productId)
        {

            if (!exists(productId))
                throw new ArgumentNullException(" product is not found");
            _dbContext.Products.Remove(_dbContext.Products.First(p => p.Id == productId));
            _dbContext.SaveChanges();
        }
        public void UpdateProduct(Product newProductData)
        {
            if (!exists(newProductData.Id))
                throw new ArgumentNullException(" product is not found");

            _dbContext.Products.Update(newProductData);
            _dbContext.SaveChanges();
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
                UpdateProduct(product);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }


        }
    }
}
