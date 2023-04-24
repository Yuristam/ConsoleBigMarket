using System.Globalization;

namespace ConsoleBigMarket.Services
{
    public class DeliveryService
    {
        public static void OrderProduct()
        {
            Product product = new Product();
            Random random = new Random();
            while (true)
            {
                Console.Clear();
                Console.Write("This is Delivery Service\n\n" +
                    "If you want to exit, type 'exit'\n" +
                    "Enter the product's name\n\n" +
                    ">");

                string userInput = Console.ReadLine().ToLower().Trim();
                if (userInput == "exit")
                {
                    Console.Clear();
                    break;
                }
                if (userInput.Any(char.IsLetter))
                {
                    product.Price = random.Next(1, 100);
                    product.Name = userInput;
                    ConfirmPurchase(product);
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("You've typed wrong symbol, please type letters.");
                    Thread.Sleep(1000);
                    Console.ResetColor();
                }
            }
        }
        static void ConfirmPurchase(Product product)
        {
            Random random = new Random();
            while (true)
            {
                Console.Clear();
                Console.Write($"Your product is {product.Name}. It costs {product.Price}$\n\n" +
                    $"If you want to cancel it, type 'cancel'\n" +
                    $"If you want to buy, enter your address\n\n>");

                string userInput = Console.ReadLine().Trim();
                if (userInput == "cancel")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    int hours = random.Next(0, 4);
                    int minutes = random.Next(10, 50);
                    Console.Clear();
                    Console.WriteLine($"Thank you for the purchase!\n\n" +
                        $"We will deliver your {product.Name} to {userInput} in {hours}:{minutes} hours.\n\n" +
                        $"Press any key to exit");
                    Console.ReadKey();
                    Console.Clear();
                    Program.Main();
                }
            }
        }
    }
}
