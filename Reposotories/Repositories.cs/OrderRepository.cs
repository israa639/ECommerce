namespace Repository.Repositories.cs
{
    public class OrderRepository : IOrderRepository
    {
        readonly IUserRepository _userRepository = new UserRepository();
        readonly IProductRepository _productRepository = new ProductRepository();
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
