

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userReository;
        private readonly UserSignUpValidator _userSignUpValidator;
        private readonly ILogger _logger;


        public UserService(IUserRepository userReository, UserSignUpValidator userSignUpValidator, ILogger logger)
        {
            _userReository = userReository;
            _userSignUpValidator = userSignUpValidator;
            _logger = logger;
        }

        public List<string> SignUp(UserSignupDTO userSignupDTO)
        {

            List<string> errors = _userSignUpValidator.Validate(userSignupDTO);
            if (!errors.Any())
            {
                var userId = Guid.NewGuid().ToString();
                var ShoppingCartId = Guid.NewGuid().ToString();

                User SignUpUser = new()
                {
                    Id = userId,
                    CreatedBy = userId,
                    CreatedOn = DateTime.Now,
                    UserName = userSignupDTO.UserName,
                    Password = userSignupDTO.Password,
                    Address = userSignupDTO.Address,
                    Email = userSignupDTO.Email,
                    ShoppingCart = new() { Id = ShoppingCartId, CreatedBy = userId },

                };
                CheckForExistingUser(SignUpUser);


                try
                {
                    _userReository.Insert(SignUpUser);
                    Log.Information($"user {SignUpUser.Id} registered successfully");
                }
                catch (Exception ex)
                {
                    Log.Error("error happened while registering new user");
                    errors.Add(ex.InnerException.ToString());
                }

            }
            else
            {
                errors.AddRange(errors);
            }
            return errors;



        }
        public List<string> SignIn(UserSignInDTO userSignInDTO)
        {
            List<string> errors = new();

            if (userSignInDTO == null || string.IsNullOrEmpty(userSignInDTO.UserName) || string.IsNullOrEmpty(userSignInDTO.Password))
            {
                errors.Add("you should enter userName and password");
            }
            try
            {
                User signInUser = GetCurrentUser(userSignInDTO.UserName);


                if (signInUser.Password != userSignInDTO.Password)
                {
                    errors.Add("incorrect password");

                }

            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
            }

            return errors;
        }

        public User GetCurrentUser(string userName)
        {
            var currentUser = _userReository.FindUserByUserName(userName);
            if (currentUser is null)
                throw new ArgumentException(" user is not found");

            return currentUser;
        }

        private void CheckForExistingUser(User user)
        {
            if (_userReository.DoesEmailExist(user.Email) || _userReository.DoesUsernameExist(user.UserName))
                throw new InvalidOperationException("Username or Email already exist.");
        }










    }
}
