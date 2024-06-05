namespace HyperMarket.Financials;

public class DebetCard : PaymentCard
{
    private const float PaymentLimit = 50;

    public DebetCard(string holderName, string number) : base(holderName, number)
    {

    }

    // transaction
    public override bool Pay(float sum)
    {
        if (sum < AvailabeMoneySum && sum <= PaymentLimit)
        {
            AvailabeMoneySum -= sum;
            return true;
        }
        return false;
    }

}
