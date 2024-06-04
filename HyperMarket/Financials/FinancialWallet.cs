using System.Collections;

namespace OOPSample.Financials;

internal class FinancialWallet : IEnumerable<IPayment>
{
    List<IPayment> _paymentMeans;

    public FinancialWallet()
    {
        _paymentMeans = new List<IPayment>();
    }

    public void AddPaymentMean(IPayment payment)
    {
        // add check here
        _paymentMeans.Add(payment);
    }

    public List<IPayment> this[string typeName]
    {
        get
        {
            var newList = new List<IPayment>();
            foreach (var item in _paymentMeans)
            {
                if (typeName == "PaymentCard" && item is PaymentCard)
                {
                    newList.Add(item);
                }
                if (typeName == "Crypto" && item is CryptoMoney)
                {
                    newList.Add(item);
                }
            }
            return newList;
        }
    }
    /// <summary>
    /// THis method to pay
    /// </summary>
    /// <param name="sum"></param>
    /// <exception cref="Exception">Exception tobe thrown if not enough money</exception>

    public void Pay(float sum)
    {
        foreach (var item in _paymentMeans)
        {
            if (item.Pay(sum))
            {
                return;
            }
        }

        throw new Exception();
    }

    public IEnumerator<IPayment> GetEnumerator() => _paymentMeans.Where(x => x is PaymentCard).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
