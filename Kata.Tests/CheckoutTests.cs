
using Kata.Kata;
using Xunit;

namespace Kata.Tests;

public class CheckoutTests
{
    private Checkout checkout;

    public CheckoutTests()
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

        checkout = new Checkout(products, discounts);

    }

    [Fact]
    public void Scan_Null_False()
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

        var checkout = new Checkout(products, discounts);

        var result = checkout.Scan(null);
        Assert.False(result);

    }

    [Fact]
    public void Scan_BadItem_False()
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


        Item item = new Item { SKU = "WrongSKU", Price = 0.50m };

        var checkout = new Checkout(products, discounts);

        var result = checkout.Scan(item);

        Assert.False(result);

    }

    [Theory]
    [InlineData(new string[] { "A99", "B15", "C40" }, new double[] { 0.5, 0.3, 0.6 }, 1.4)]
    public void Total_No_Discount_Applied(string[] skus, double[] prices, decimal expected)
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

        var checkout = new Checkout(products, discounts);

        for (int i = 0; i < skus.Length; i++)
        {
            Item item = new Item { SKU = skus[i], Price = (decimal)prices[i] };

            checkout.Scan(item);

        }
        var price = checkout.Total();

        Assert.Equal(expected, price);

    }

    [Theory]
    [InlineData(new string[] { "A99", "A99", "A99" }, new double[] { 0.5, 0.5, 0.5 }, 1.3)]
    [InlineData(new string[] { "B15", "B15", }, new double[] { 0.3, 0.3 }, 0.45)]

    public void Total_With_Discount_Applied(string[] skus, double[] prices, decimal expected)
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

        var checkout = new Checkout(products, discounts);

        for (int i = 0; i < skus.Length; i++)
        {
            Item item = new Item { SKU = skus[i], Price = (decimal)prices[i] };

            checkout.Scan(item);

        }
        var price = checkout.Total();

        Assert.Equal(expected, price);

    }
}