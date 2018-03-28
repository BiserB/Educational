
public class ClinicFactory
{
    public Clinic Create(string name, int rooms)
    {
        return new Clinic(name, rooms);
    }
}
