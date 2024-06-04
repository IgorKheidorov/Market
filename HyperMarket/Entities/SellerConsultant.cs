namespace OOPSample.Entities;

internal class SellerConsultant
{
    public string Name { get; }
    public string Speciality { get; }

    public SellerConsultant(string name, string speciality)
    {
        Name = name;
        Speciality = speciality;
    }
}
