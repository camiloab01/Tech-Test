using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxCalculator
{
    public class Book : Product
    {
        /// <summary>
        /// Books are exempted of sales taxes, except for imported books
        /// </summary>
        /// <returns></returns>
        public override double CalculateSalesTax()
        {
            double salesTax = 0;

            if (IsImported)
            {
                salesTax += Price * 0.05;
            }

            return salesTax;
        }
    }
}
