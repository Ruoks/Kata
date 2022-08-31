
using Kata.Kata;
using Xunit;

namespace Kata.Tests;

public class CheckoutTests
{

    [Fact]
    public void Scan_Null_False()
    {
        var checkout = new Checkout();

        var result = checkout.Scan(null);
        Assert.False(result);

    }

    [Fact]
    public void Scan_BadItem_False()
    {
        Item item = new Item { SKU = "WrongSKU", Price = 0.50m };

        var checkout = new Checkout();

        var result = checkout.Scan(item);

        Assert.False(result);

    }
}