namespace OOPSample.Entitys;

internal class SellerConsultant : Entity
{
    public string Name { get; }
    public string Speciality { get; }

    public SellerConsultant(string name, string speciality)
    {
        Name = name;
        Speciality = speciality;
    }
}
