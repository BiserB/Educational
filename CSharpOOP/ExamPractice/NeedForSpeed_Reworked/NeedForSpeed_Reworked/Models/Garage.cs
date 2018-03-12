using System.Collections.Generic;

public class Garage
{
    private Dictionary<int, Car> parkedCars;

    public Garage()
    {
        ParkedCars = new Dictionary<int, Car>();
    }

    public Dictionary<int, Car> ParkedCars
    {
        get { return parkedCars; }
        set { parkedCars = value; }
    }

    public void ModifyCars(int tuneIndex, string tuneAddOn)
    {
        foreach (Car car in ParkedCars.Values)
        {
            car.Horsepower += tuneIndex;
            car.Suspension += (int)(tuneIndex * 0.5);
            string type = car.GetType().Name;

            if (type == "ShowCar")
            {
                car.Upgrade(tuneIndex.ToString());
            }
            else
            {
                car.Upgrade(tuneAddOn);
            }
        }
    }
}