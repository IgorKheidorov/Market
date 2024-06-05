using HyperMarket.DAL;
using HyperMarket.Entityies;
using HyperMarket.Interfaces;
using HyperMarket.Repositories;
using OOPSample.Entities;
using OOPSample.Repositories;
using System.Linq;

namespace HyperMarket.Infrastructure;

internal class UnitOfWork : IUnitOfWork
{
    // allocate memory -> all object are one by one-> memory addresses are finished (more then 90%)
    // GC works _. looks for memory and find not used object (no reference to these objects on stack)
    // GC copy all survived objects to other memory location (call first generation) and them clear memory
    // StringBuilder -> id you have more then 5-7 string concat operations-> use it

    JSONProductRepository _JSONProductRepository;
    JSONProductDescriptionRepository _JSONProductDescriptionRepository;
    JSONSellerConsultantsRepository _JSONSellerConsultantsRepository;
        
    public JSONProductRepository JSONProductRepository => _JSONProductRepository ??= new JSONProductRepository();
    public JSONSellerConsultantsRepository JSONSellerConsultantsRepository => _JSONSellerConsultantsRepository ??= new JSONSellerConsultantsRepository();
    public JSONProductDescriptionRepository JSONProductDescriptionRepository => _JSONProductDescriptionRepository ??= new JSONProductDescriptionRepository();

    public IEnumerable<SellerConsultant> GetElectronicsDepartmentSellerConsultants()=>
        JSONSellerConsultantsRepository.GetAll();

    public IEnumerable<SellerConsultant> GetFoodDepartmentSellerConsultants()=>
        JSONSellerConsultantsRepository.GetAll();

    private List<Product> PopulateProduct(ProductEntity product, ProductDescriptionEntity? description)=>
        Enumerable.Range(1, product.Count)
        .Select(x=> new Product(product.Name, product.Category, product.Price, new ProductDescription() { Details = description.Details })).ToList();

    public IEnumerable<Product> GetProducts(Func<Product, bool> filter) 
    {
        var productDescriptionEntities = JSONProductDescriptionRepository.GetAll();
        return JSONProductRepository.GetAll()
            .SelectMany(x=> PopulateProduct(x, productDescriptionEntities.FirstOrDefault(y => y.Id == x.DescriptionID))).
            Where(filter).ToList();
    } 

    public bool SaveConsultants(IEnumerable<SellerConsultant> consultants)
    {
        throw new NotImplementedException();
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

        JSONProductRepository.SaveAll(entities.Select(x => x.Item1));
        JSONProductDescriptionRepository.SaveAll(entities.Select(x => x.Item2));

        return true;
    }
}
