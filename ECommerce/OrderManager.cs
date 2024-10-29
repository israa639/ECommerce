namespace ECommerce
{
    internal class OrderManager
    {

        private IOrderService _orderService;

        public OrderManager(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public void MakeOrder(User currentUser)
        {
            if (currentUser.ShoppingCart.HasNoItems())
                WriteLine("No Item In The Cart");
            else
            {
                try
                {
                    _orderService.PlaceOrder(currentUser);
                    WriteLine("Order has been placed successfully!");
                }
                catch (Exception ex)
                {
                    WriteLine(ex);
                }
            }

        }
        public void ViewOrderHistory(User currentUser)
        {
            WriteLine("Your Orders History");
            WriteLine("----------------------------");
            foreach (var order in currentUser.Orders)
            {
                WriteLine(order);
            }
        }
    }
}
