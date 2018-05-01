
public interface IWasteFactory
{
    IWaste CreateWaste(string name, double weight, double volumePerKg, string type);
}
