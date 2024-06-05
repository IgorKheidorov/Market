namespace JSON_Repository.DAL;

public abstract class TEntity<TKey>
{
    public TKey Id { get; set; }
}
