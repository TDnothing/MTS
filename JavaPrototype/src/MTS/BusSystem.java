package MTS;

import java.util.HashMap;

public class BusSystem {
    private static HashMap<Integer, BusStop> BusStops = new HashMap();
    private static HashMap<Integer, BusRoute> BusRoutes = new HashMap();
    private static HashMap<Integer, Bus> Buses = new HashMap();

    public static Bus GetBus(int BusId){
        return Buses.containsKey(BusId) ? Buses.get(BusId) : null;
    }
    public static BusStop GetBusStop(int stopID) {
        return BusStops.containsKey(stopID) ? BusStops.get(stopID) : null;
    }
    public static BusRoute GetBusRoute(int routeID) {
        return BusRoutes.containsKey(routeID) ? BusRoutes.get(routeID) : null;
    }

    public static void MoveNextBus()
    {
        var e1 = SimEventQueue.GetLowestRankEvent();
        e1.ExecuteEvent();
        //int id = e1.GetObjectId(e1);
    }

    public static void CreateObject(String[] tokens){
        switch (tokens[0]) {
            case "add_depot":
               // System.out.println(", <ID>:" + tokens[1] + ", <Name>:" + tokens[2] + ", <X-Coord>:" + tokens[3] + ", <Y-Coord>:" + tokens[4]);
                break;
            case "add_stop":
                //System.out.println(", <ID>:" + tokens[1] + ", <Name>:" + tokens[2] + ", <Riders>:" + tokens[3] + ", <Latitude>:" + tokens[4] + ", <Longitude>:" + tokens[5]);
                BusStop busStop1 = new BusStop(Integer.parseInt(tokens[1]), tokens[2], Integer.parseInt(tokens[3]), Double.parseDouble(tokens[4]), Double.parseDouble(tokens[5]));
                BusStops.put(Integer.parseInt(tokens[1]),busStop1);
                break;
            case "add_route":
               // System.out.println(", <ID>:" + tokens[1] + ", <Number>:" + tokens[2] + ", <Name>:" + tokens[3]);
                BusRoute busRoute1 = new BusRoute(Integer.parseInt(tokens[1]), Integer.parseInt(tokens[2]), tokens[3]);
                BusRoutes.put(Integer.parseInt(tokens[1]),busRoute1);
                break;
            case "extend_route":
                //System.out.println(", <Route ID>:" + tokens[1] + ", <Stop ID>:" + tokens[2]);
                BusRoute targetRoute = GetBusRoute(Integer.parseInt(tokens[1]));
                if (targetRoute != null) targetRoute.ExtendRoute(Integer.parseInt(tokens[2]));
                break;
            case "add_bus":
               // System.out.println(", <ID>:" + tokens[1] + ", <Route>:" + tokens[2] + ", <Location>:" + tokens[3] + ", <Initial Passengers>:" + tokens[4] + ", <Passenger Capacity>:" + tokens[5] + ", <Initial Fuel>:" + tokens[6] + ", <Fuel Capacity>:" + tokens[7] + ", <Speed>:" + tokens[8]);
                Bus bus1 = new Bus(Integer.parseInt(tokens[1]), Integer.parseInt(tokens[2]), Integer.parseInt(tokens[3]), Integer.parseInt(tokens[4]), Integer.parseInt(tokens[5]),
                        Integer.parseInt(tokens[6]), Integer.parseInt(tokens[7]), Integer.parseInt(tokens[8]));
                Buses.put(Integer.parseInt(tokens[1]),bus1);
                break;
            case "add_event":
               // System.out.println(", <Time>:" + tokens[1] + ", <Type>:" + tokens[2] + ", <ID>:" + tokens[3]);
                SimEvent simEvent = new SimEvent(Integer.parseInt(tokens[1]), tokens[2], Integer.parseInt(tokens[3]));
                SimEventQueue.AddSimEventsQueue(simEvent);
                break;
            default:
                System.out.println(" command not recognized");
                break;
        }
    }

}
