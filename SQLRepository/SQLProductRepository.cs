using SuperMarketEntities.Entities;
using SuperMarketEntities.Interfaces;

namespace SQLRepository;

public class SQLProductRepository : SQLRepository<Product>
{
    public SQLProductRepository(HyperMarketContext context): base(context) { }
}