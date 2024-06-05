namespace JSON_Repository.DAL;

public class ProductEntity: Entity
{
    public string? Name { get; set; }
    public string? Category { get; set; }
    public float Price { get; set; }
    public int Count { get; set; }

    public Guid DescriptionID { get; set; }
}
