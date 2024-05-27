using OOPSample.Interfaces;
using System.Configuration;
using System.Text.Json;

namespace OOPSample.Repositories;

internal class JSONRepository<T> : IRepository<T>
{
    protected virtual string RepositoryFileName { get; set; } = "";

    protected string FullFileName => Path.Combine(ConfigurationManager.AppSettings["Repositories"]?? "", RepositoryFileName);

    public IEnumerable<T> GetAll()
    {
        var jsonString = FullFileName;
        try
        {
            jsonString = File.ReadAllText(FullFileName);
        }
        catch (Exception ex)
        {
          
        }
        
        return JsonSerializer.Deserialize<List<T>>(jsonString);        
    }

    public bool SaveAll(IEnumerable<T> products)
    {
        File.WriteAllText(RepositoryFileName, JsonSerializer.Serialize(products));
        return true;
    }
}
