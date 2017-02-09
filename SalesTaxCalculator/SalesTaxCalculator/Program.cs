using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxCalculator
{
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


        }

        private static void BuyItems(List<Product> products)
        {
            foreach(Product product in products)
            {
                product.TotalPrice = product.Price + product.CalculateSalesTax();
            }
        }

        private static void PrintReceipt(List<Product> productsBought)
        {
            double totalSalesTaxes = 0;
            double totalToPay = 0;

            
            for(int i = 0; i < productsBought.Count; i++)
            {
                Product product = productsBought[i];

                var itemsPaid = (from Product p in productsBought
                                 where p.GetType() == product.GetType()
                                 select p).ToList();

                int numberOfItemsPaid = itemsPaid.Count();

                foreach (Product item in itemsPaid)
                {
                    totalSalesTaxes += item.CalculateSalesTax();
                    totalToPay += item.TotalPrice;

                    productsBought.Remove(item);
                }

                if (numberOfItemsPaid > 1)
                {
                    Console.WriteLine("{0}: {1}, ({2} @ {3})", product.Name, product.TotalPrice * numberOfItemsPaid, numberOfItemsPaid, product.TotalPrice);
                }
                else
                {
                    Console.WriteLine("{0}: {1}", product.Name, product.TotalPrice);
                }
            }

            Console.WriteLine("Sales Taxes: {0}", totalSalesTaxes);
            Console.WriteLine("Total: {0}", totalToPay);
        }
    }
}
