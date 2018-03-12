using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Race
{
    private int length;
    private string route;
    private int prizePool;
    private List<Car> participants;

    public Race(int length, string route, int prizePool)
    {
        Length = length;
        Route = route;
        PrizePool = prizePool;
        Participants = new List<Car>();
    }

    public List<Car> Participants
    {
        get { return participants; }
        private set { participants = value; }
    }

    public int PrizePool
    {
        get { return prizePool; }
        private set { prizePool = value; }
    }

    public string Route
    {
        get { return route; }
        private set { route = value; }
    }

    public int Length
    {
        get { return length; }
        private set { length = value; }
    }

    public virtual void AddCar(Car car)
    {
        participants.Add(car);
    }

    public abstract string Finish();

    public int CalcPrize(int i)
    {
        switch (i)
        {
            case 1:
                return (int)(PrizePool * 0.5);                

            case 2:
                return (int)(PrizePool * 0.3);

            case 3:
                return (int)(PrizePool * 0.2);

            default:
                return 0;
        }
    }
}