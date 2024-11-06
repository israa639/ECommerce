

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        AppDbContext _dbContext;




        readonly IUserRepository _userRepository;
        readonly IProductRepository _productRepository;
        public OrderRepository(IUserRepository userRepository, IProductRepository productRepository, AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }



        public Decimal PlaceOrder(User user)
        {
            decimal totalPrice = 0;
            if (user is null)
            { throw new ArgumentException("User not found."); }
            totalPrice = user.MakeOrder();
            _userRepository.Update(user);
            return totalPrice;
        }


    }
}
