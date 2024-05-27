using System.Collections;

namespace OOPSample.Entitys;

internal class WareHouse : Entity, IEnumerable<Product>
{
    List<Product> _products = new();
    List<string> _specialEquipment = new();

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void AddEquipment(string equipmentName)
    {
        _specialEquipment.Add(equipmentName);
    }

    public IEnumerator<Product> GetEnumerator()
    {
        return _products.GetEnumerator();
    }

    public void ExcludeProduct(object? buyer, PurchaseEventArgs args)
    {
        var productToBeRemoved = _products.Find(x => (x as Product)?.Name == args.ProductName);
        if (productToBeRemoved == default)
        {
            throw new Exception();
        }

        (buyer as Buyer)?.AddPurchase(productToBeRemoved);
        _products.Remove(productToBeRemoved);
    }

    private void FillGoodsList()
    {
        _products.Add(new Product("Bread", 0.5f));
        _products.Add(new Product("Bread", 0.5f));
        _products.Add(new Product("Bread", 0.5f));
        _products.Add(new Product("Bread", 0.5f));
        _products.Add(new Product("Bread", 0.5f));
        _products.Add(new Product("Milk", 1f));
        _products.Add(new Product("Milk", 1f));
        _products.Add(new Product("Milk", 1f));
        _products.Add(new Product("Milk", 1f));
        _products.Add(new Product("Milk", 1f));
        _products.Add(new Product("Beer", 2.5f));
        _products.Add(new Product("Beer", 2.5f));
        _products.Add(new Product("Beer", 2.5f));
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _products.GetEnumerator();
    }
}
