namespace SuperMarketEntities.Entities;

public class SellerConsultant
{
    public string Name { get; }
    public string Speciality { get; }

    public SellerConsultant() { }

    public SellerConsultant(string name, string speciality)
    {
        Name = name;
        Speciality = speciality;
    }
}
