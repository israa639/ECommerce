
namespace Repository.Repositories
{
    public class UserRepository : IUserRepository
    {

        public void Insert(User user)
        {
            if (user is not null &&
                !string.IsNullOrEmpty(user.Email) &&
                !string.IsNullOrEmpty(user.UserName))
            {
                if (DoesUsernameExist(user.UserName) || DoesEmailExist(user.Email))
                    throw new Exception("UserName or Email already exist");

                DataStore.Users.AddFirst(user);
                DataStore.UserNames.Add(user.UserName);
                DataStore.Emails.Add(user.Email);
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

            return DataStore.Users.FirstOrDefault(u => u.UserName == userName);

        }
        private bool DoesUsernameExist(string userName)
        {
            return DataStore.UserNames.Contains(userName);
        }
        private bool DoesEmailExist(string email)
        {
            return DataStore.Emails.Contains(email);
        }

        public void Update(string userId, User newUserData)
        {
            Delete(userId);
            Insert(newUserData);
        }

        public void Delete(string userId)
        {
            User userToBeRemoved = DataStore.Users.FirstOrDefault(u => u.UserID == userId);
            if (userToBeRemoved is null)
                throw new ArgumentException("user is not found");
            DataStore.Emails.Remove(userToBeRemoved.Email);
            DataStore.UserNames.Remove(userToBeRemoved.UserName);
            DataStore.Users.Remove(userToBeRemoved);

        }

        public User FindUserById(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentNullException(" Username cannot be empty");

            }

            return DataStore.Users.FirstOrDefault(u => u.UserID == userId);
        }
    }
}
