package MTS;

import javafx.util.Pair;

import java.util.ArrayList;

public class BusRoute {
    public Integer Id;
    public Integer _number;
    public String _name;
    private ArrayList _busStops = new ArrayList();

    public BusRoute(Integer id, Integer number, String name)
    {
        Id = id;
        _name = name;
        _number = number;
    }

    public void ExtendRoute(Integer stopid)
    {
        _busStops.add(stopid);
    }

    public Pair<Integer,Integer> GetBusStopInfoByBusLocation(Integer location)
    {
        if (location >= _busStops.size()) return new Pair<>(0, (Integer) _busStops.get(0));

        return new Pair<>(location, (Integer)_busStops.get(location));
    }
}
