
namespace SuperMarketEntities.Entities;

public class DescriptionEntity  
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }

    public DescriptionEntity() { }
    public DescriptionEntity(string key, string value) 
    {
        Key = key;
        Value = value;
    }
}


public class ProductDescription
{
    public int Id { get; set; }
    //public Dictionary<string, string> Details { get; set; } = new Dictionary<string, string>();
    public List<DescriptionEntity> Details { get; set; } = new List<DescriptionEntity>();

    public ProductDescription() { }

    public override bool Equals(object? obj) =>
        obj is ProductDescription description ? Details.SequenceEqual(description.Details): false;

    public override int GetHashCode() =>
        Details.GetHashCode();   
}
