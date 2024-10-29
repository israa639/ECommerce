namespace ECommerce
{
    internal class ProductManager
    {
        private static IProductService _productService = new ProductService();



        public static void DisplayProducts()
        {
            foreach (var product in _productService.GetAllProducts())
            {
                WriteLine(product);
            }
            //DisplayPostRegistrationMenu();
        }
    }
}
