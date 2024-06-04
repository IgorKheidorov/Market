namespace OOPSample.Financials;

// all tyoes are inheretitant from object
public abstract class PaymentCard : IPayment, IComparable<PaymentCard>// CAN'T EXISTS IN A REAL LIFE
{
    public virtual string HolderName { get; }
    protected string _number;

    public virtual string Number
    {
        get => _number;
        protected set => _number = value.Length == 3 ? value : throw new ArgumentException();
    }

    public float AvailabeMoneySum { get; set; } // abstract thing

    public PaymentCard(string holderName, string number)
    {
        Number = number is not null ? number : throw new ArgumentNullException();
        HolderName = holderName is not null ? holderName : throw new ArgumentNullException(); 
    }

    public override bool Equals(object? obj)
    {
        return (obj as PaymentCard)?.HolderName == HolderName;
    }


    public virtual string GetInfo() // can be overriden
    {
        return $"Card holder: {HolderName}, Card number :{Number}, Available money: {AvailabeMoneySum}";
    }

    public abstract bool Pay(float sum);

    public override int GetHashCode()
    {
        // collisions
        return HolderName.Length;
    }

    public int CompareTo(PaymentCard? other) => AvailabeMoneySum.CompareTo(other?.AvailabeMoneySum);

}
