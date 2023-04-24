namespace ConsoleBigMarket.Services
{
    public class MarketService
    {
        public static void SelectProduct()
        {
            List<Product> basket = new List<Product>();
            Random random = new Random();
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(0,0);
                Console.Write("This is Market's Main Room\n\n" +
                    "Enter your product(s) to buy\n" +
                    "If you completed your shopping, enter 'exit'\n\n>");
                
                Console.SetCursorPosition(0,8);
                Console.Write("Your Products List:\n"+ new string('-', 40));
                for (int i = 0; i < basket.Count; i++)
                {
                    Console.Write($"\n{i + 1}) {basket[i].Name} {basket[i].Price}$");
                }

                Console.SetCursorPosition(1, 5);
                Product product = new Product();
                product.Name = Console.ReadLine().ToLower().Trim();
                if (product.Name == "exit")
                {
                    break;
                }
                if (product.Name.Any(char.IsLetter))
                {
                    product.Price = random.Next(1, 100);
                    basket.Add(product);
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
            CheckProduct(basket);
        }

        static void CheckProduct(List<Product> basket)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Your Products List:\n"+ new string('-', 40));

                float total = 0;
                for (int i = 0; i < basket.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {basket[i].Name} {basket[i].Price}$");
                    total += basket[i].Price;
                }

                Console.WriteLine(new string('-',40) + $"\nTotal: {total} $");

                Console.Write("\n\nEnter OK to buy all products\n\n" +
                    "If you want to delete product, enter the name of the product then enter remove\n\n");

                string userInput = Console.ReadLine().ToLower().Trim();

                for (int i = 0; i < basket.Count; i++)
                {
                    if (userInput == $"delete {i+1}")
                        basket.RemoveAt(i);
                }

                if (userInput == "ok")
                {
                    Console.Clear();
                    Console.WriteLine("Thank you for the purchase!");
                    Console.WriteLine("Press any key to go to the main menu.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
               /* else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("You've typed wrong symbol, please type letters.");
                    Thread.Sleep(1000);
                    Console.ResetColor();
                }*/
            }
        }
    }
}
