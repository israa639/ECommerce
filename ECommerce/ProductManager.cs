namespace ECommerce
{
    internal class ProductManager
    {
        private readonly IProductService _productService;


        public ProductManager(IProductService productService)
        {
            _productService = productService;
        }
        public void DisplayProducts()
        {
            foreach (var product in _productService.GetAllProducts())
            {
                WriteLine(product);
            }

        }
    }
}
