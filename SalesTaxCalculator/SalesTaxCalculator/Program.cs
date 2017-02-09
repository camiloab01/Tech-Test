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
            List<Product> shoppingList = new List<Product>();

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
            
            foreach(Product product in productsBought)
            {
                var itemsPaid = (from Product p in productsBought
                                 where p.GetType() == product.GetType()
                                 select p);

                int numberOfItemsPaid = itemsPaid.Count();

                foreach (var item in itemsPaid)
                {
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

                totalSalesTaxes += product.CalculateSalesTax() * numberOfItemsPaid;
                totalToPay += product.TotalPrice * numberOfItemsPaid;
            }

            Console.WriteLine("Sales Taxes: {0}", totalSalesTaxes);
            Console.WriteLine("Total: {0}", totalToPay);
        }
    }
}
