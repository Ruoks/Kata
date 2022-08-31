using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    namespace Kata
    {
        public class Checkout
        {
            private readonly IEnumerable<IItem> products;
            private readonly IEnumerable<ISpecialOffer> discounts;
            private string[] scannedProducts;
            private List<IItem> basket;

            public Checkout(IEnumerable<IItem> products, IEnumerable<ISpecialOffer> discounts)
            {
                this.products = products;
                this.discounts = discounts;
                scannedProducts = new string[] { };
                basket = new List<IItem>();
            }

            public decimal Total()
            {
                return 0m;
            }

            public bool Scan(Item item)
            {
                //check if item is not null and if item exist in our products
                if (item != null && products.Any(product => product.SKU == item.SKU))
                {
                    basket.Add(item);

                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

    }

}
