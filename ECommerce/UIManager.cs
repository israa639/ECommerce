namespace ECommerce
{

    internal class UIManager
    {
        private readonly UserService _userService = new();
        private readonly ShoppingCartManager _shoppingCartManager = new ShoppingCartManager();
        private OrderManager orderManager = new OrderManager();
        private User currentUser = new User();
        public void Start()
        {
            DisplayPreRegistrationMenu();
        }


        private void DisplayPreRegistrationMenu()
        {
            WriteLine(@"Welcome!
               press 1 to SignIn
               press 2  to SignUp");
            int userChoice = UserInputHandler.ReadUserMenuChoice();

            switch (userChoice)
            {
                case 1:
                    SignInUI();
                    break;
                case 2:
                    SignUpUI();
                    break;
            }

        }

        private void DisplayPostRegistrationMenu()
        {
            WriteLine(@"
               press 1 to view our products
               press 2  to view your shopping cart
               press 3  to add Item to your cart
               press 4  to update your shopping cart
               press 5 to delete from your cart
               press 6 to view your past orders
");
            int userChoice = UserInputHandler.ReadUserMenuChoice();
            switch (userChoice)
            {
                case 1: ProductManager.DisplayProducts(); break;
                case 2: _shoppingCartManager.DisplayUserShoppingCartUI(currentUser); break;
                case 3: _shoppingCartManager.AddItemToCartUI(currentUser); break;
                case 4: _shoppingCartManager.UpdateItemInTheCartUI(currentUser); break;
                case 5: _shoppingCartManager.RemoveItemFromTheCartUI(currentUser); break;
                case 6: orderManager.ViewOrderHistory(currentUser); break;
                default: _shoppingCartManager.DisplayUserShoppingCartUI(currentUser); break;


            }
            DisplayPostRegistrationMenu();
        }

        private static void DisplayErrors(IEnumerable<string> errors)
        {
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }
        }
        private void SignUpUI()
        {
            UserSignupDTO newUser = UserInputHandler.ReadUserSignUpData();

            List<string> signUpErrors = _userService.SignUp(newUser);
            if (signUpErrors.Any())
            {
                DisplayErrors(signUpErrors);
                SignUpUI();
            }
            else
            {
                currentUser = _userService.GetCurrentUser(newUser.UserName);
                DisplayPostRegistrationMenu();
            }

        }
        private void SignInUI()
        {
            UserSignInDTO SignInuser = UserInputHandler.ReadUserSignInData();

            List<string> signInErrors = _userService.SignIn(SignInuser);
            if (signInErrors.Any())
            {
                DisplayErrors(signInErrors);
                SignInUI();
            }
            else
            {
                currentUser = _userService.GetCurrentUser(SignInuser.UserName);
                DisplayPostRegistrationMenu();
            }

        }




    }
}