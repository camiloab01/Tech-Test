using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxCalculator
{
    public class Product
    {
        public String Name { get; set; }

        public double Price { get; set; }

        public double TotalPrice { get; set; }

        public bool IsImported { get; set; }

        /// <summary>
        /// All Products with some exceptions will be charged with 10% of sales tax
        /// </summary>
        /// <returns></returns>
        public virtual double CalculateSalesTax()
        {
            double salesTax = 0;

            salesTax = Price * 0.10;

            if(IsImported)
            {
                salesTax += Price * 0.05;
            }

            return salesTax;
        }
    }
}
