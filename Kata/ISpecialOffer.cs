namespace Kata
{
    public interface ISpecialOffer
    {
        string SKU { get; set; }
        int Quantity { get; set; }
        decimal Value { get; set; }
    }
}