using OOPSample.Financials;

namespace OOPSample.Entitys;
internal class PurchaseEventArgs : EventArgs
{
    public string? ProductName { get; }
    public float? Price { get; }
    public PurchaseEventArgs(string? productName, float? price)
    {
        ProductName = productName;
        Price = price;
    }
}

internal class Buyer
{
    FinancialWallet _wallet;
    public string FullName { get; set; }
    public int Age { get; }

    //Publisher - bloger
    // duty to call all subscribed methods!!!
    // event will be raised if payment is successfull!!!
    public event EventHandler<PurchaseEventArgs>? PaymentSuccess;

    public Buyer(string fullName, int age)
    {
        FullName = fullName;
        Age = age;
        _wallet = CreateWallet();
    }

    public List<Entity> Purchases { get; } = new List<Entity>();

    public bool Pay(string productName, float sum)
    {
        foreach (var item in _wallet)
        {
            if (item.Pay(sum))
            {
                // raise event (invoke)
                // List of delegates
                PaymentSuccess?.Invoke(this, new PurchaseEventArgs(productName, sum));
                return true;
            }
        }

        return false;
    }

    public void AddPurchase(Entity product)
    {
        Purchases.Add(product);
    }

    private FinancialWallet CreateWallet()
    {
        _wallet = new FinancialWallet();
        _wallet.AddPaymentMean(new CreditCard("name1", "111") { AvailabeMoneySum = 100 });
        _wallet.AddPaymentMean(new DebetCard("name2", "222") { AvailabeMoneySum = 50 });
        _wallet.AddPaymentMean(new CryptoMoney());
        return _wallet;
    }

}
