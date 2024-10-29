namespace Service.IServices
{
    public interface IUserService
    {
        public List<string> SignUp(UserSignupDTO userSignupDTO);

        public List<string> SignIn(UserSignInDTO userSignInDTO);


        public User GetCurrentUser(string userName);
    }
}
