


using Domain.Models;

namespace ECommerce
{

    internal class UIManager
    {
        private static UserService _userService = new();
        private static ProductService _productService = new();
        private static ShoppingCartService _shoppingCartService = new();
        private static OrderService _orderService = new();
        User currentUser = new User();
        public void Run()
        {
            DisplayPreRegistrationMenu();
        }
        private static string ReadDataFromUser(String message)
        {
            WriteLine(message);
            String Input = ReadLine();
            return Input;

        }
        private static int GetUserMenuChoice()
        {
            int userChoice;
            while (!int.TryParse(ReadLine(), out userChoice))
                WriteLine("please Enter a valid choice");
            return userChoice;

        }
        private static int ReadIntegerInput(string message)
        {
            int userChoice;
            WriteLine(message);
            while (!int.TryParse(ReadLine(), out userChoice))
                WriteLine("please Enter a valid choice");
            return userChoice;

        }
        private void DisplayPreRegistrationMenu()
        {
            WriteLine(@"Welcome!
               press 1 to SignIn
               press 2  to SignUp");
            int userChoice = GetUserMenuChoice();

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
        private UserSignupDTO GetUserSignUpData()
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
                    Address = new()
                    {
                        country = country,
                        city = city,
                        street = street
                    }
                };


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return newUser;
        }
        private UserSignInDTO GetUserSignInData()
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

        private static void DisplayErrors(IEnumerable<string> errors)
        {
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }
        }
        private void SignUpUI()
        {
            UserSignupDTO newUser = GetUserSignUpData();

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
            UserSignInDTO SignInuser = GetUserSignInData();

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
            int userChoice = GetUserMenuChoice();
            switch (userChoice)
            {
                case 1: DisplayProductsUI(); break;
                case 2: DisplayUserShoppingCartUI(); break;
                case 3: AddItemToCartUI(); break;
                case 4: UpdateItemInTheCartUI(); break;
                case 5: RemoveItemFromTheCartUI(); break;
                case 6: ViewOrderHistoryUI(); break;
                default: DisplayUserShoppingCartUI(); break;


            }
        }
        private void DisplayProductsUI()
        {
            foreach (var product in _productService.GetAllProducts())
            {
                WriteLine(product);
            }
            DisplayPostRegistrationMenu();
        }

        private void DisplayUserShoppingCartUI()
        {
            WriteLine("Your shopping Cart");
            WriteLine("----------------------------------------");
            foreach (var item in currentUser.ShoppingCart.items.Values)
            {
                WriteLine(item);
            }
            WriteLine(@"
               press 1 to order your shopping Cart
               press 2 to return to menu
                 ");

            int userChoice = GetUserMenuChoice();

            switch (userChoice)
            {
                case 1:
                    MakeOrderUI();
                    break;
                case 2:
                    DisplayPostRegistrationMenu();
                    break;
                default:
                    DisplayUserShoppingCartUI();
                    break;
            }

        }
        private void AddItemToCartUI()
        {
            int productId = ReadIntegerInput("Enter the ID of the product:");
            int quantity = ReadIntegerInput("Enter the quantity of the product:");
            try
            {
                _shoppingCartService.AddToCart(currentUser, productId, quantity);
            }
            catch (Exception ex)
            {
                WriteLine($"Error Happened while adding to the cart {ex.Message}");
            }
            finally
            {
                DisplayUserShoppingCartUI();
            }
        }
        private void RemoveItemFromTheCartUI()
        {
            int productId = ReadIntegerInput("Enter the id of the item to be removed :");
            try
            {
                _shoppingCartService.DeleteFromCart(currentUser, productId);
            }
            catch (Exception ex)
            {
                WriteLine($"Error Happened while deleting from the cart {ex.Message}");
            }
            finally
            {
                DisplayUserShoppingCartUI();
            }

        }
        private void UpdateItemInTheCartUI()
        {
            int productId = ReadIntegerInput("Enter the id of the item to be Updated:");
            int quantity = ReadIntegerInput("Enter the new quantity of the item to be Updated:");
            try
            {
                _shoppingCartService.UpdateCart(currentUser, productId, quantity);
            }
            catch (Exception ex)
            {
                WriteLine($"Error Happened while Updating the cart {ex.Message}");
            }
            finally
            {
                DisplayUserShoppingCartUI();
            }

        }

        private void MakeOrderUI()
        {
            if (currentUser.ShoppingCart.HasNoItems())
                WriteLine("No Item In The Cart");
            else
            {
                try
                {
                    _orderService.PlaceOrder(currentUser);
                    WriteLine("Order has been placed successfully!");
                }
                catch (Exception ex)
                {
                    WriteLine(ex);
                }


            }
            DisplayPostRegistrationMenu();

        }
        private void ViewOrderHistoryUI()
        {
            WriteLine("Your Orders History");
            WriteLine("----------------------------");
            foreach (var order in currentUser.Orders)
            {
                WriteLine(order);
            }
            DisplayPostRegistrationMenu();
        }

    }
}
