

public static class WasteExtension
{
    public static double CalcVolume(this IWaste waste)
    {
        return waste.Weight * waste.VolumePerKg;
    }
}