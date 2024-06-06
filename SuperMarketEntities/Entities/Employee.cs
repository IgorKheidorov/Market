namespace SuperMarketEntities.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public EmployeeRole Role { get; set; }

    public Employee() { }

    public Employee(string name, EmployeeRole role)
    {
        Name = name;
        Role = role;
    }
}
