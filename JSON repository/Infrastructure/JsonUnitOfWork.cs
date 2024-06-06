using JSON_Repository.DAL;
using JSON_Repository.Repositories;
using SuperMarketEntities.Entities;
using SuperMarketEntities.Interfaces;

namespace JSON_Repository.Infrastructure;

public class JsonUnitOfWork : IUnitOfWork
{
    // allocate memory -> all object are one by one-> memory addresses are finished (more then 90%)
    // GC works _. looks for memory and find not used object (no reference to these objects on stack)
    // GC copy all survived objects to other memory location (call first generation) and them clear memory
    // StringBuilder -> id you have more then 5-7 string concat operations-> use it

    JSONProductRepository _JSONProductRepository;
    JSONProductDescriptionRepository _JSONProductDescriptionRepository;
    JSONEmployeeRepository _JSONEmployeeRepository;
        
    public string Name { get; }
    public string SourcePath { get; }


    public JsonUnitOfWork(string name, string sourcePath) 
    {
        Name = name;
        SourcePath = sourcePath;
        _JSONProductDescriptionRepository = new(Name, SourcePath);
        _JSONProductRepository = new(Name, SourcePath);
        _JSONEmployeeRepository = new(Name, SourcePath);
    }

    private List<Product> PopulateProduct(ProductEntity product, ProductDescriptionEntity? description)=>
        Enumerable.Range(1, product.Count)
        .Select(x=> new Product(product.Name, product.Category, product.Price, new ProductDescription() { Details = description.Details })).ToList();

    public IEnumerable<Product> GetProducts(Func<Product, bool> filter) 
    {
        var productDescriptionEntities = _JSONProductDescriptionRepository.GetAll();
        return _JSONProductRepository.GetAll()
            .SelectMany(x=> PopulateProduct(x, productDescriptionEntities.FirstOrDefault(y => y.Id == x.DescriptionID))).
            Where(filter).ToList();
    } 

 
    public bool SaveProducts(IEnumerable<Product> products)
    {
        var entities = products
            .GroupBy(product => product)
            .Select(x => (new ProductEntity()
            {
                Id = Guid.NewGuid(),
                Name = x.Key.Name,
                Category = x.Key.Category,
                Price = x.Key.Price,
                Count = x.Count()
            },
            new ProductDescriptionEntity()
            {
               Id = Guid.NewGuid(),
               Details = x.Key.Description.Details
            })).ToList();

        // Set DescriptionID to products
        entities.ForEach(x => x.Item1.DescriptionID = x.Item2.Id);

        _JSONProductRepository.SaveAll(entities.Select(x => x.Item1));
        _JSONProductDescriptionRepository.SaveAll(entities.Select(x => x.Item2));

        return true;
    }

    public IEnumerable<Employee> GetPersonal() =>
        _JSONEmployeeRepository.GetAll();

    public bool SavePersonal(IEnumerable<Employee> employees) =>
        _JSONEmployeeRepository.SaveAll(employees);

    public void Dispose()
    {
        
    }
}
