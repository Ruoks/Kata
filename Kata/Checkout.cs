using System;
using System.Collections.Generic;
using System.Text;

namespace Kata
{
    namespace Kata
    {
        public class Checkout
        {
            public Checkout()
            {

            }

            public decimal Total()
            {
                return 0m;
            }

            public bool Scan(Item item)
            {
                if (item != null && item.SKU != "WrongSKU")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public class Item
        {
            public string SKU { get; set; }
            public decimal Price { get; set; }
        }
    }

}
