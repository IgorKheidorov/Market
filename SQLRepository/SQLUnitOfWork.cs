using SuperMarketEntities.Entities;
using SuperMarketEntities.Interfaces;

namespace SQLRepository;

public class SQLUnitOfWork : IUnitOfWork
{
    HyperMarketContext _context;

    private SQLEmployeeRepository _SQLEmployeeRepository;
    private SQLProductRepository _SQLProductRepository;

    public SQLUnitOfWork(string dbName) 
    {
        _context = new HyperMarketContext(dbName);
        _SQLEmployeeRepository = new SQLEmployeeRepository(_context);
        _SQLProductRepository = new SQLProductRepository(_context);
    }

    public IEnumerable<Employee> GetPersonal() =>
        _SQLEmployeeRepository.GetAll();

    public IEnumerable<Product> GetProducts(Func<Product, bool> filter) =>
        _SQLProductRepository.GetAll().Where(filter).ToList();

    public void AddEmployees(IEnumerable<Employee> employees)
    {
        _SQLEmployeeRepository.dbSet.AddRange(employees);
    }
        
    public bool SavePersonal(IEnumerable<Employee> employees)
    {   
        _context.SaveChanges();
        return true;
    }

    public void AddProducts(IEnumerable<Product> products)
    {
        _SQLProductRepository.dbSet.AddRange(products);
    }

    public bool SaveProducts(IEnumerable<Product> products)
    {  
        _context.SaveChanges();
        return true;
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
