public class AggressiveDriver : Driver
{
    public AggressiveDriver(string name, double totalTime, Car car)
                    : base(name, totalTime, car, 2.7)
    {
        Speed *= 1.3;
    }
}