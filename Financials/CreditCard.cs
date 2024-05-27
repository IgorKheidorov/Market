namespace OOPSample.Financials;

public class CreditCard : PaymentCard
{
    private const int LENGTH_LIMIT = 3;
    public float CreditAmount { get; set; }

    public CreditCard(string holderName, string number) : base(holderName, number) { }

    public override string Number
    {
        protected set
        {
            if (value.Length == LENGTH_LIMIT) // magic number
            {
                _number = value;
                return;
            }
            throw new Exception();
        }
    }

    public override string GetInfo()
    {
        return $"Card holder: {HolderName}, Card number :{Number}, Available money: {AvailabeMoneySum}, Credit amount: {CreditAmount}";
    }

    public override bool Pay(float sum)
    {
        if (sum < AvailabeMoneySum + CreditAmount)
        {
            AvailabeMoneySum -= sum;
            return true;

        }
        return false;
    }


}
