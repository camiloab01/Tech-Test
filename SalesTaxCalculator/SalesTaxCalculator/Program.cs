using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxCalculator
{

    /// <summary>
    /// This Program will calculate the sales taxes of a shopping list
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Product> shoppingList;

            Console.WriteLine("*******************Scenario 1*******************");

            shoppingList = new List<Product>();

            shoppingList.Add(new Book { Name = "Book", Price = 12.49, IsImported = false });
            shoppingList.Add(new Book { Name = "Book", Price = 12.49, IsImported = false });
            shoppingList.Add(new Product { Name = "Music CD", Price = 14.99, IsImported = false });
            shoppingList.Add(new Food { Name = "Chocolate bar", Price = 0.85, IsImported = false });

            BuyItems(shoppingList);
            PrintReceipt(shoppingList);

            Console.WriteLine("*******************Scenario 2*******************");

            shoppingList = new List<Product>();

            shoppingList.Add(new Product { Name = "Imported bottle of perfune", Price = 47.50, IsImported = true });
            shoppingList.Add(new Food { Name = "Imported box of chocolates", Price = 10, IsImported = true });

            BuyItems(shoppingList);
            PrintReceipt(shoppingList);

            Console.WriteLine("*******************Scenario 3*******************");

            shoppingList = new List<Product>();

            shoppingList.Add(new Product { Name = "Imported bottle of perfune", Price = 27.99, IsImported = true });
            shoppingList.Add(new Product { Name = "Bottle of perfune", Price = 18.99, IsImported = false });
            shoppingList.Add(new MedicalProduct { Name = "Packet of headache pills", Price = 9.75, IsImported = false });
            shoppingList.Add(new Food { Name = "Imported box of chocolates", Price = 11.25, IsImported = true });
            shoppingList.Add(new Food { Name = "Imported box of chocolates", Price = 11.25, IsImported = true });

            BuyItems(shoppingList);
            PrintReceipt(shoppingList);

            Console.ReadKey();
        }

        /// <summary>
        /// Update each of the products with its corresponding Total Price
        /// </summary>
        /// <param name="products"></param>
        private static void BuyItems(List<Product> products)
        {
            foreach(Product product in products)
            {
                product.TotalPrice = product.Price + product.CalculateSalesTax();
            }
        }

        /// <summary>
        /// Prints the receipt with the corresponding sales tax and total price to pay
        /// </summary>
        /// <param name="productsBought"></param>
        private static void PrintReceipt(List<Product> productsBought)
        {
            double totalSalesTaxes = 0;
            double totalToPay = 0;

            //Loop into the products to get their sales tax and price and print it in screen
            for(int i = productsBought.Count; i >= productsBought.Count && productsBought.Count != 0; i--)
            {
                Product product = productsBought.Last();

                //Get the items of the same type that were bought, example: 2 books
                var itemsPaid = (from Product p in productsBought
                                 where p.GetType() == product.GetType()
                                 select p).ToList();

                int numberOfItemsPaid = itemsPaid.Count();

                //Loop into the items paid to get the sales tax, total price and remove them from the products bought list
                foreach (Product item in itemsPaid)
                {
                    totalSalesTaxes += Math.Round(item.CalculateSalesTax()*2, MidpointRounding.AwayFromZero)/2;
                    totalToPay += item.TotalPrice;

                    productsBought.Remove(item);
                }

                //Print in screen the Item or items with its corresponding total price, the way it is printed depends on how many articles of the same type were bought
                if (numberOfItemsPaid > 1)
                {
                    Console.WriteLine("{0}: {1}, ({2} @ {3})", product.Name, product.TotalPrice * numberOfItemsPaid, numberOfItemsPaid, product.TotalPrice);
                }
                else
                {
                    Console.WriteLine("{0}: {1}", product.Name, product.TotalPrice);
                }
            }

            //Print the total to pay and the total sales taxes for all the bought products
            Console.WriteLine("Sales Taxes: {0}", totalSalesTaxes);
            Console.WriteLine("Total: {0}", totalToPay);
        }
    }
}
