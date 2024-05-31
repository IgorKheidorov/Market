using HyperMarket.DAL;

namespace HyperMarket.Entityies;

internal class ProductDescription
{
    public Dictionary<string, string> Details { get; set; } = new Dictionary<string, string>();
    public override bool Equals(object? obj) =>
        obj is ProductDescription description ? Details.SequenceEqual(description.Details): false;

    public override int GetHashCode() =>
        Details.GetHashCode();   
}
