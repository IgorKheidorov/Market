using SuperMarketEntities.Interfaces;
using System.Text.Json;

namespace JSON_Repository.Repositories;

internal abstract class JSONRepository<T> : IRepository<T>
{
    public string Name;
    public string SourcePath;
    protected virtual string RepositoryFileName { get; set; } = "";
        
    protected string FullFileName => Path.Combine(SourcePath, Name, RepositoryFileName);

    public JSONRepository(string name, string path) 
    {
        Name = name;
        SourcePath = path;
    }

    public IEnumerable<T> GetAll()
    {
        if (!File.Exists(FullFileName))
        {   
            SaveAll(new List<T>());
        }
        using StreamReader reader = new StreamReader(FullFileName);
        
        return JsonSerializer.Deserialize<List<T>>(reader.ReadToEnd());    
    }


    public virtual bool SaveAll(IEnumerable<T> data)
    {
        if (!Directory.Exists(Path.Combine(SourcePath, Name)))
        {
            Directory.CreateDirectory(Path.Combine(SourcePath, Name));
        }

        var options = new FileStreamOptions()
        {
            Mode = FileMode.Create,            
        };

        options.Access = FileAccess.Write;

        using (StreamWriter writer = new StreamWriter(FullFileName, options))
        {
            var jsonString = JsonSerializer.Serialize<List<T>>(data.ToList());
            writer.Write(jsonString);
            return true;
        }
    }
}
