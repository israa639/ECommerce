namespace Service.Services
{
    public class ProductService
    {
        readonly IProductRepository _ProductRepository = new ProductRepository();
        public List<Product> GetAllProducts()
        {
            return _ProductRepository.GetAllProducts();

        }




    }
}
