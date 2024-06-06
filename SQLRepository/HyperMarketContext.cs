using Microsoft.EntityFrameworkCore;
using SuperMarketEntities.Entities;
using System.Data.Common;

namespace SQLRepository;

public class HyperMarketContext: DbContext
{
    private string _connectionString;
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Employee> Employees { get; set; }

    private string DbName;

    public HyperMarketContext(string connectionString)
    {
        DbName = connectionString;
        Database.EnsureCreated();        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = $"Server=.\\SQLEXPRESS;Trusted_Connection = True;TrustServerCertificate=True;Database={"HyperMarket" + DbName}";
        optionsBuilder.UseSqlServer(connectionString);
    }
}
