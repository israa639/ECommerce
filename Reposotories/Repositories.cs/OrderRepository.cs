namespace Repository.Repositories.cs
{
    public class OrderRepository : IOrderRepository
    {
        readonly IUserRepository _userRepository;
        readonly IProductRepository _productRepository;
        public OrderRepository(IUserRepository userRepository, IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
        }



        public Decimal PlaceOrder(User user)
        {
            decimal totalPrice = 0;
            if (user is null)
            { throw new ArgumentException("User not found."); }
            totalPrice = user.MakeOrder();
            _userRepository.Update(user.UserID, user);
            return totalPrice;
        }


    }
}
