namespace Service.Services
{
    public class ProductService
    {
        readonly IProductRepository _ProductRepository = new ProductRepository();
        public IEnumerable<Product> GetAllProducts()
        {
            return _ProductRepository.GetAllProducts();

        }




    }
}
