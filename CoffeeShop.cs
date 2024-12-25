using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop
{
    abstract class CoffeeShop
    {
        private double balance; // Encapsulated field for balance

        protected CoffeeShop(double initialBalance)
        {
            Balance = initialBalance;
        }

        // Encapsulated property for balance
        public double Balance
        {
            get { return balance; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance cannot be negative.");
                }
                balance = value;
            }
        }
             // Abstract method to be implemented in derived classes
    public abstract void PlaceOrder(string item, double price);

        // Non-abstract method to display the balance
        public void DisplayBalance()
        {
            Console.WriteLine($"Current shop balance: ${Balance:F2}");
        }

        // Protected method to add to balance (used by derived classes)
        protected void AddToBalance(double amount)
        {
            Balance += amount;
        }
    }

    class Cafe : CoffeeShop
    {
        public Cafe(double initialBalance) : base(initialBalance) { }

        // Override the abstract method for placing an order
        public override void PlaceOrder(string item, double price)
        {
            if (price < 0)
            {
                throw new InvalidPriceException("Price cannot be negative.");
            }

            AddToBalance(price);
            Console.WriteLine($"Order placed: {item} - ${price:F2}");
        }
    }

}
