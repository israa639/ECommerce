namespace ECommerce
{
    internal class ShoppingCartManager
    {
        private ShoppingCartService _shoppingCartService = new();
        OrderManager orderManager = new OrderManager();


        public void DisplayUserShoppingCartUI(User currentUser)
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

            int userChoice = UserInputHandler.ReadUserMenuChoice();

            if (userChoice == 1)
                orderManager.MakeOrder(currentUser);
        }
        public void AddItemToCartUI(User currentUser)
        {
            int productId = UserInputHandler.ReadIntegerInput("Enter the ID of the product:");
            int quantity = UserInputHandler.ReadIntegerInput("Enter the quantity of the product:");
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
                DisplayUserShoppingCartUI(currentUser);
            }
        }
        public void RemoveItemFromTheCartUI(User currentUser)
        {
            int productId = UserInputHandler.ReadIntegerInput("Enter the id of the item to be removed :");
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
                DisplayUserShoppingCartUI(currentUser);
            }

        }
        public void UpdateItemInTheCartUI(User currentUser)
        {
            int productId = UserInputHandler.ReadIntegerInput("Enter the id of the item to be Updated:");
            int quantity = UserInputHandler.ReadIntegerInput("Enter the new quantity of the item to be Updated:");
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
                DisplayUserShoppingCartUI(currentUser);
            }

        }

    }
}
