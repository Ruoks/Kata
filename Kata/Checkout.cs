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
            private List<IItem> basket;

            public Checkout(IEnumerable<IItem> products, IEnumerable<ISpecialOffer> discounts)
            {
                this.products = products;
                this.discounts = discounts;
                basket = new List<IItem>();
            }

            public decimal Total()
            {
                decimal total = 0;
                decimal totalDiscount = 0;

                foreach (Item item in basket)
                {
                    total += PriceFor(item);
                }

                foreach (ISpecialOffer discount in discounts)
                {
                    totalDiscount += CalculateDiscount(discount, basket);
                }

                Console.WriteLine("Price before Discount: " + total + "£");
                Console.WriteLine("Discount Applied: " + totalDiscount + "£");
                Console.WriteLine("Price After Discount: " + (total - totalDiscount) + "£");

                return total - totalDiscount;
            }

            private decimal CalculateDiscount(ISpecialOffer discount, List<IItem> cart)
            {
                int itemCount = cart.Count(item => item.SKU == discount.SKU);

                decimal itemPrice = products.Single(item => item.SKU == discount.SKU).Price;

                int numberOfDiscountCanBeApplied = (int)(itemCount / discount.Quantity);

                if (numberOfDiscountCanBeApplied == 0)
                {
                    return 0;
                }
                return numberOfDiscountCanBeApplied * ((itemPrice * discount.Quantity) - discount.Value);

            }

            private decimal PriceFor(Item item)
            {
                return products.Single(i => i.SKU == item.SKU).Price;
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
