public class Company
{
    
    public Company(string companyName, string department, decimal salary)
    {
        this.Name = companyName;
        this.Department = department;
        this.Salary = salary;
    }

    public string Name { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }

    public override string ToString()
    {
        return $"{this.Name} {this.Department} {this.Salary}";
    }
}