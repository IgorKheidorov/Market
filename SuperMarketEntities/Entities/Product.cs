
namespace SuperMarketEntities.Entities;

public class Product 
{
    public int Id { get; set; }
    public string Name { get; private set; }
    public string Category { get; set; } // enum
    public float Price { get; private set; }

    public Product() { }

    public ProductDescription Description { get; set; } = new ProductDescription();

    public Product(string name, string category, float price, ProductDescription desciption)
    {   
        Name = name is not null ? name : throw new NullReferenceException();
        Category = category;
        Price = price;
        Description = desciption;
    }

    public override bool Equals(object? obj) =>
        obj is Product product ? product.Name == Name
        && Category == product.Category
        && float.Epsilon > product.Price - Price
        && Description.Equals(product.Description) : false;

    public override int GetHashCode()=>
        Name.GetHashCode() ^ Description.GetHashCode();
}
