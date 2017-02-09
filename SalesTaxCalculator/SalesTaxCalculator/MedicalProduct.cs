using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesTaxCalculator
{
    class MedicalProduct : Product
    {
        /// <summary>
        /// Medical Products are exempted of sales taxes, except for imported Medical Products
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
