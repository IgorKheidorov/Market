
namespace HyperMarket.DAL;

internal class ProductDescriptionEntity: Entity
{
    public Dictionary<string, string> Details { get; set; } = new Dictionary<string, string>();
}
