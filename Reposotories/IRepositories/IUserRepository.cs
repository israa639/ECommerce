﻿namespace Repository.IRepositories
{
    public interface IUserRepository
    {
        public void Insert(User entity);
        public User FindUserByUserName(string userName);
        public User FindUserById(string userId);
        public void Update(string userId, User newUserData);
        public void Delete(string userId);





    }
}