namespace OOPSample.Entitys;

internal class Product : Entity
{
    public string Name { get; private set; } 
    public float Price { get; private set; }

    public Product(string name, float price)
    {
        Id = Guid.NewGuid();
        Name = name is not null ? name : throw new NullReferenceException();
        Price = price;
    }
}
