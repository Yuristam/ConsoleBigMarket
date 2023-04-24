using ConsoleBigMarket;
using ConsoleBigMarket.Services;

internal class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Welcome to our Market");
            for (int i = 0; i < Console.BufferWidth; i++)
            {
                Console.Write("=");
            }
            Console.Write("1. Buy product\n" +
                "2. Order product\n" +
                "3. Exit\n\n>");

            int userInput = Convert.ToInt32(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    Console.Clear();
                    MarketService.SelectProduct();
                    break;
                case 2:
                    Console.Clear();
                    DeliveryService.OrderProduct();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Good Bye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("There is no such command. Please enter right command");
                    break;
            }
        }
    }
}