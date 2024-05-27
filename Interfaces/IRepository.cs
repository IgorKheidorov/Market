namespace OOPSample.Interfaces;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    bool SaveAll(IEnumerable<T> products);
}
