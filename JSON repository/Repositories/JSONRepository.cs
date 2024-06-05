using SuperMarketEntities.Interfaces;
using System.Text.Json;

namespace JSON_Repository.Repositories;

internal abstract class JSONRepository<T> : IRepository<T>
{
    protected virtual string RepositoryFileName { get; set; } = "";

    
    protected string FullFileName => Path.Combine("D:\\Trainings\\SuperMarket\\JSON repository\\Data", RepositoryFileName);

    public IEnumerable<T> GetAll()
    {
        if (!File.Exists(FullFileName))
        {   
            SaveAll(new List<T>());
        }
        using StreamReader reader = new StreamReader(FullFileName);
        
        return JsonSerializer.Deserialize<List<T>>(reader.ReadToEnd());    
    }

    
    public virtual bool SaveAll(IEnumerable<T> products)
    {
        using (StreamWriter writer = new StreamWriter(FullFileName))
        {
            var jsonString = JsonSerializer.Serialize<List<T>>(products.ToList());
            writer.Write(jsonString);
            return true;
        }
    }
}
