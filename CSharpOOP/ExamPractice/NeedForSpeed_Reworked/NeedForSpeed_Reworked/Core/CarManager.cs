using System.Collections.Generic;

public class CarManager
{
    private readonly string ZERO_PARTICIPANTS = "Cannot start the race with zero participants.";

    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;

    public CarManager()
    {
        cars = new Dictionary<int, Car>();
        races = new Dictionary<int, Race>();
        garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        Car car = CarFactory.Produce(type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        if (car != null)
        {
            cars[id] = car;
        }
    }

    public string Check(int id)
    {
        if (cars[id] == null)
        {
            return garage.ParkedCars[id].ToString();
        }
        return cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool, int timeORlaps)
    {
        Race race = RaceFactory.Produce(type, length, route, prizePool, timeORlaps);
        if (race != null)
        {
            races[id] = race;
        }
    }

    public void Participate(int carId, int raceId)
    {
        if (races.ContainsKey(raceId) && cars[carId] != null)
        {
            races[raceId].AddCar(cars[carId]);
        }
    }

    public string Start(int id)
    {
        if (races[id].Participants.Count == 0)
        {
            return ZERO_PARTICIPANTS;
        }
        string result = races[id].Finish();
        races.Remove(id);
        return result;
    }

    public void Park(int id)
    {
        Car car = cars[id];
        foreach (var race in races.Values)
        {
            if (race.Participants.Contains(car))
            {
                return;
            }
        }
        garage.ParkedCars[id] = car;
        cars[id] = null;
    }

    public void Unpark(int id)
    {
        Car car = garage.ParkedCars[id];
        garage.ParkedCars.Remove(id);
        cars[id] = car;
    }

    public void Tune(int tuneIndex, string tuneAddOn)
    {
        garage.ModifyCars(tuneIndex, tuneAddOn);
    }
}