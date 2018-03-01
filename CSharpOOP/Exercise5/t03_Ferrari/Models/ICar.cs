
public interface ICar
{
    string Make { get; set; }
    string Model { get; set; }
    Driver Driver { get; set; }

    string UseBreaks();
    string PushTheGasPedal();
}
