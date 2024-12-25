using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class InvalidPriceException : Exception
{
    public InvalidPriceException(string message) : base(message) { }
}

class ItemNameNullException : Exception
{
    public ItemNameNullException(string message) : base(message) { }
}


namespace CoffeeShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Coffee Shop!");

            // Initialize the coffee shop with an initial balance
            CoffeeShop myCafe = new Cafe(100.00);

            // User input loop
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Place an Order");
                Console.WriteLine("2. View Balance");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.Write("Enter item name: ");
                            string itemName = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(itemName))
                            {
                                throw new ItemNameNullException("Item name cannot be empty or null.");
                            }

                            Console.Write("Enter item price: ");
                            if (double.TryParse(Console.ReadLine(), out double itemPrice))
                            {
                                myCafe.PlaceOrder(itemName, itemPrice);
                            }
                            else
                            {
                                throw new InvalidPriceException("Invalid price format. Please enter a valid number.");
                            }
                        }
                        catch (ItemNameNullException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        catch (InvalidPriceException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

                        break;

                    case "2":
                        myCafe.DisplayBalance();
                        break;

                    case "3":
                        Console.WriteLine("Thank you for visiting! Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
