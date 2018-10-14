package MTS;

public class SimEvent {
    public Integer _rank;
    public String _type;
    public Integer _objectId;

    public SimEvent()
    { }
    public SimEvent(Integer rank, String type, Integer objectId)
    {
        _rank = rank;
        _type = type;
        _objectId = objectId;
    }


    public void ExecuteEvent()
    {
        Bus currentBus = BusSystem.GetBus(_objectId);
        //Console.WriteLine("rank: {0}: move_bus ID: {1}", _rank, currentBus.Id);
        int NextRank = currentBus.Move(_rank);
        SimEvent nextEvent = new SimEvent(NextRank + _rank,"move bus",currentBus.Id);
        SimEventQueue.AddSimEventsQueue(nextEvent);
    }
}
