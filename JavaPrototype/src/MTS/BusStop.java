package MTS;

public class BusStop{
    public int Id;
    public String _name;
    private int _riders;
    private double Latitude;
    private double Longitude;
    public BusStop(int ID, String name, int riders, double latitude, double longitude)
    {
        Id = ID;
        _name = name;
        _riders = riders;
        Latitude = latitude;
        Longitude = longitude;
    }
    public static int CalculateTimeWithSpeed(BusStop stopA, BusStop stopB, int currentBusSpeed)
    {

        Double distance = 70.0 * Math.sqrt(Math.pow((stopA.Latitude -
                stopB.Latitude), 2) + Math.pow((stopA.Longitude - stopB.Longitude), 2));

        int travel_time = 1 + (distance.intValue() * 60 / currentBusSpeed);
        return travel_time;
    }

    public void UpdateStopRidersByBus(int onbus, int offbus)
    {
        _riders += (onbus + offbus);
    }
}
