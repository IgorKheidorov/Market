﻿using OOPSample.Interfaces;
using System.Configuration;
using System.Text.Json;

namespace OOPSample.Repositories;

internal class JSONRepository<T> : IRepository<T>
{
    protected virtual string RepositoryFileName { get; set; } = "";

    protected string FullFileName => Path.Combine(ConfigurationManager.AppSettings["Repositories"]?? "", RepositoryFileName);

    public IEnumerable<T> GetAll()
    {
        if (!File.Exists(FullFileName))
        {
            SaveAll(new List<T>());
        }
        using StreamReader reader = new StreamReader(FullFileName);
        
        return JsonSerializer.Deserialize<List<T>>(reader.ReadToEnd());    
    }

    public bool SaveAll(IEnumerable<T> products)
    {
        using (StreamWriter writer = new StreamWriter(FullFileName))
        {
            var jsonString = JsonSerializer.Serialize<List<T>>(products.ToList());
            writer.Write(jsonString);
            return true;
        }
    }
}
