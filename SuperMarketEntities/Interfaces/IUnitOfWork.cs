using SuperMarketEntities.Entities;

namespace SuperMarketEntities.Interfaces;

public interface IUnitOfWork: IDisposable
{
    IEnumerable<Product> GetProducts(Func<Product, bool> filter);
    bool SaveProducts(IEnumerable<Product> products);
    IEnumerable<Employee> GetPersonal();
    bool SavePersonal(IEnumerable<Employee> employees);    
}
