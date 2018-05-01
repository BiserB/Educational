
public interface IRecyclingManager
{
    string ProcessGarbage(string name, double weight, double volumePerKg, string type);

    string Status();
}
