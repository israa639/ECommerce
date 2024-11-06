namespace ECommerce
{
    internal static class UserInputHandler
    {
        public static string ReadDataFromUser(String message)
        {
            WriteLine(message);
            String Input = ReadLine();
            return Input;

        }
        public static int ReadUserMenuChoice()
        {
            int userChoice;
            while (!int.TryParse(ReadLine(), out userChoice))
                WriteLine("please Enter a valid choice");
            return userChoice;

        }
        public static int ReadIntegerInput(string message)
        {
            int userChoice;
            WriteLine(message);
            while (!int.TryParse(ReadLine(), out userChoice))
                WriteLine("please Enter a valid choice");
            return userChoice;

        }
        public static UserSignupDTO ReadUserSignUpData()
        {
            UserSignupDTO newUser = null;
            try
            {

                String userName = ReadDataFromUser("Enter your UserName:");
                String password = ReadDataFromUser("Enter your password");
                String confirmPassword = ReadDataFromUser("confirm your password");
                String email = ReadDataFromUser("Enter your Email");
                String country = ReadDataFromUser("Enter your Country");
                String city = ReadDataFromUser("Enter your City");
                String street = ReadDataFromUser("Enter your Street");

                newUser = new()
                {
                    UserName = userName,
                    Password = password,
                    ConfirmPassword = confirmPassword,
                    Email = email,
                    Address = $"{street},{city},{country}"
                };


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return newUser;
        }
        public static UserSignInDTO ReadUserSignInData()
        {
            UserSignInDTO userSignInDTO = null;

            try
            {

                string UserName = ReadDataFromUser("Enter your UserName:");
                string Password = ReadDataFromUser("Enter your password");


                userSignInDTO = new UserSignInDTO() { UserName = UserName, Password = Password };


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return userSignInDTO;
        }

    }
}
