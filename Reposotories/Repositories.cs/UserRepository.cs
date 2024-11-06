
namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Insert(User user)
        {
            if (user is not null)
            {


                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException("user, email, Username cannot be null");
            }
        }
        public User FindUserByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(" Username cannot be empty");

            }

            return _dbContext.Users.FirstOrDefault(u => u.UserName == userName);

        }
        public bool DoesUsernameExist(string userName)
        {
            return _dbContext.Users.Any(u => u.UserName == userName);
        }
        public bool DoesEmailExist(string email)
        {
            return _dbContext.Users.Any(u => u.Email == email);
        }

        public void Update(User newUserData)
        {
            _dbContext.Users.Update(newUserData);
            _dbContext.SaveChanges();
        }

        public void Delete(string userId)
        {
            User userToBeRemoved = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (userToBeRemoved is null)
                throw new ArgumentException("user is not found");
            _dbContext.Users.Remove(userToBeRemoved);
            _dbContext.SaveChanges();

        }

        public User FindUserById(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException(" Username cannot be empty");

            }

            return _dbContext.Users.FirstOrDefault(u => u.Id == userId);
        }
    }
}
