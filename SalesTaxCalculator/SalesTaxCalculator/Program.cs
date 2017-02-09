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
            foreach(Product product in productsBought)
            {
                int productQuantity = productsBought.Select(x => x.GetType)
            }
        }
    }
}
