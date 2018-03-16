

public class Track
{ 
    private Weather weather;

    public Track(int lapsNumber, int trackLength)
    {
        RaceLaps = lapsNumber;
        Length = trackLength;
        Weather = Weather.Sunny;
        CurrentLap = 0;
        
    }

    public int RaceLaps { get; }
    public int Length { get; }
    public int CurrentLap { get; set; }
    

    public Weather Weather
    {
        get { return weather; }
        private set { weather = value; }
    }

    public void SetWeather(Weather newWeather)
    {
        Weather = newWeather;
    }
}
