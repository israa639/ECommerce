﻿namespace Service.Services
{
    public class UserService
    {
        readonly private IUserRepository _userReository = new UserRepository();
        readonly private UserSignUpValidator _userSignUpValidator = new UserSignUpValidator();
        public List<string> SignUp(UserSignupDTO userSignupDTO)
        {

            List<string> errors = _userSignUpValidator.Validate(userSignupDTO);
            if (!errors.Any())
            {
                User SignUpUser = new()
                {
                    UserID = Guid.NewGuid().ToString(),
                    UserName = userSignupDTO.UserName,
                    Password = userSignupDTO.Password,
                    Address = userSignupDTO.Address,
                    Email = userSignupDTO.Email
                };


                try
                {
                    _userReository.Insert(SignUpUser);
                }
                catch (Exception ex)
                {
                    errors.Add(ex.Message);
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
                User signInUser = _userReository.FindUserByUserName(userSignInDTO.UserName);
                if (signInUser is null)
                {
                    errors.Add("userName is not found");
                }
                else
                {
                    if (signInUser.Password != userSignInDTO.Password)
                    {
                        errors.Add("incorrect password");

                    }
                }
            }
            catch (Exception ex)
            {
                errors.Add("UserName or password shouldn't be empty");
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










    }
}