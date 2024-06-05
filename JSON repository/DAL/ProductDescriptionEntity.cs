using SuperMarketEntities.Entities;

namespace JSON_Repository.DAL;

internal class ProductDescriptionEntity: Entity
{
    public List<DescriptionEntity> Details { get; set; } = new List<DescriptionEntity>();
}
