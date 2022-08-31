using Kata.Kata;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<IItem> products = new[]
            {
                new Item{SKU = "A99", Price = 0.50m},
                new Item{SKU = "B15", Price = 0.30m},
                new Item{SKU = "C40", Price = 0.60m},
            };

            IEnumerable<ISpecialOffer> discounts = new[]
                {
                new SpecialOffer{SKU = "A99", Quantity = 3, Value = 1.30m},
                new SpecialOffer{SKU = "B15", Quantity = 2, Value = 0.45m}
            };

            IEnumerable<IItem> items = new[]
            {
                new Item{SKU = "A99", Price = 0.50m},
                new Item{SKU = "B15", Price = 0.30m},
                new Item{SKU = "C40", Price = 0.60m},
                new Item{SKU = "A99", Price = 0.50m},
                new Item{SKU = "A99", Price = 0.50m},
            };

            Checkout checkOut = new Checkout(products, discounts);

            foreach (Item item in items)
            {
                bool successfullyScanned = checkOut.Scan(item);

            }

            var price = checkOut.Total();

        }

    }
}
