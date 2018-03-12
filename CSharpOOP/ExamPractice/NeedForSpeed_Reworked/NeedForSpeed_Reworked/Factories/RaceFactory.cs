public static class RaceFactory
{
    public static Race Produce(string type, int length, string route, int prizePool, int timeORlaps)
    {
        switch (type)
        {
            case "Casual":
                return new CasualRace(length, route, prizePool);

            case "Drag":
                return new DragRace(length, route, prizePool);

            case "Drift":
                return new DriftRace(length, route, prizePool);

            case "TimeLimit":
                return new TimeLimitRace(length, route, prizePool, timeORlaps);

            case "Circuit":
                return new CircuitRace(length, route, prizePool, timeORlaps);

            default:
                return null;
        }
    }
}