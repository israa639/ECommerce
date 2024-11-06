namespace Core.IRepositories
{
    public interface IUserRepository
    {
        public void Insert(User entity);
        public User FindUserByUserName(string userName);
        public User FindUserById(string userId);
        public void Update(User newUserData);
        public void Delete(string userId);
        public bool DoesUsernameExist(string userName);

        public bool DoesEmailExist(string email);






    }
}
