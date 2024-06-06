using SuperMarketEntities.Interfaces;

namespace HyperMarket.Interfaces;

internal interface IHyperMarketCreator
{
    bool CreateEmployees();
    bool CreateProducts();
    IUnitOfWork GetDataSource();
}
