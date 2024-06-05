namespace HyperMarket.DAL;

internal abstract class TEntity<TKey>
{
    public TKey Id { get; set; }
}
