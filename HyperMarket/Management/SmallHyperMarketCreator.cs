using HyperMarket.Interfaces;
using JSON_Repository.Infrastructure;
using SuperMarketEntities.Entities;
using SuperMarketEntities.Interfaces;

namespace HyperMarket.Management;

internal class SmallHyperMarketCreator : IHyperMarketCreator
{
    IUnitOfWork _unitOfWork;

    public SmallHyperMarketCreator(string name, string sourcePath)
    {
        _unitOfWork = new JsonUnitOfWork(name, sourcePath);
    }

    public bool CreateEmployees()
    {
        if(_unitOfWork.GetPersonal().Count() == 0) 
        {
            List<Employee> employees = new List<Employee>()
            {
            new Employee("Jack", EmployeeRole.GeneralManager),
            new Employee("Mike", EmployeeRole.MarketingSpecialist),
            new Employee("Paul", EmployeeRole.Seller),
            new Employee("Kate", EmployeeRole.Seller),
            new Employee("John", EmployeeRole.Worker),
            };

            return _unitOfWork.SavePersonal(employees);
        }

        return false;
    }

    public bool CreateProducts()
    {
        if (_unitOfWork.GetProducts(x => true).Count() == 0)
        { 
            List<Product> products = new();

        ProductDescription milkDescription1 = new()
        {
            Details = new() {
          { new DescriptionEntity("Еat content", "1.5%") },
          {new DescriptionEntity("Producer", "Milk company") },
          {new DescriptionEntity("Expirity date", "05-11-2024") },
        }
        };

        ProductDescription milkDescription2 = new()
        {
            Details = new() {
          {new DescriptionEntity("Еat content", "3.5%") },
          {new DescriptionEntity("Producer", "Milk company") },
          {new DescriptionEntity("Expirity date", "05-11-2024") },
        }
        };

        ProductDescription tvPanasonicDescription = new()
        {
            Details = new() {
          {new DescriptionEntity("Model", "TX-65LX650E 65\" LED 4K Android TV Dolby Vision Dolby Atmos HDMI 2.1") },
          {new DescriptionEntity("Producer", "Panasonic") },
          {new DescriptionEntity("Guarantee period", "5 years")},
        }
        };

        ProductDescription iPhoneDescription = new()
        {
            Details = new() {
          {new DescriptionEntity("Model", "14") },
          {new DescriptionEntity("Producer", "Apple") },
          {new DescriptionEntity("Guarantee period", "2 years")},
        }
        };

        for (int i = 0; i < 5; i++)
        {
            products.Add(new Product("Milk", "Food", 0.9f, milkDescription1));
            products.Add(new Product("Milk", "Food", 1.5f, milkDescription2));
            products.Add(new Product("TV", "Electronics", 1000f, tvPanasonicDescription));
            products.Add(new Product("Modile phone", "Electronics", 2000f, iPhoneDescription));
        }

        return _unitOfWork.SaveProducts(products);
        }
        return false;
    }

    public IUnitOfWork GetDataSource() => _unitOfWork;
}
