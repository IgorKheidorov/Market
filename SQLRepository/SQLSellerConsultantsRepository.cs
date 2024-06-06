using SuperMarketEntities.Entities;
using SuperMarketEntities.Interfaces;

namespace SQLRepository;

public class SQLEmployeeRepository : SQLRepository<Employee>
{
    public SQLEmployeeRepository(HyperMarketContext context) : base(context) { }    
}