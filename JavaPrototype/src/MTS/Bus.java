package MTS;

public class Bus {
    public int Id;
    public int RouteId;
    public int Location;
    private int _currentPassengers;
    private int _passengerCapacity;
    private int _currentFuel;
    private int _fuelCapactiy;
    public int Speed;

    public Bus(int id, int routeId,int location,int initialPassengers,
               int passengerCapacity,int currentFuel,int feFuelCapactiy, int speed)
    {
        Id = id;
        RouteId = routeId;
        Location = location;
        _currentPassengers = initialPassengers;
        _passengerCapacity = passengerCapacity;
        _currentFuel = currentFuel;
        _fuelCapactiy = feFuelCapactiy;
        Speed = speed;
    }
    public void UpdateBusLocation(int nextStopId)
    {
        Location = nextStopId;
    }
    public int Move(int rank)
    {
        BusRoute currentRoute = BusSystem.GetBusRoute(RouteId);

        int currentStopId = currentRoute.GetBusStopInfoByBusLocation(Location).getValue();
        var resut = currentRoute.GetBusStopInfoByBusLocation(Location + 1);
        int nextStopId = resut.getValue();
        int nextStopLocation = resut.getKey();

        BusStop currentStop = BusSystem.GetBusStop(currentStopId);
        BusStop nextStop = BusSystem.GetBusStop(nextStopId);

        //Bus left current stop
        // int offBus = BusRider.GetRiderOffBus(nextStopId, rank);
        // int onBus = BusRider.GetRiderOnBus(nextStopId, rank);

        //UpdateBusPassenger(offBus, onBus);
        UpdateBusLocation(nextStopLocation);
        //nextStop.UpdateStopRidersByBus(onBus, offBus);

        int time = BusStop.CalculateTimeWithSpeed(currentStop, nextStop, Speed);

        //System.out.println(", <Route ID>:" + tokens[1] + ", <Stop ID>:" + tokens[2]);
        System.out.println("b:" + Id + "->s:" + nextStopId + "@" + (time+rank) +"//p:"+ 0 + "/f:" + 0);
        return time;

    }
}
