package MTS;

import java.util.Comparator;
import java.util.LinkedList;
import javafx.scene.layout.Priority;
import java.util.*;


public class SimEventQueue {
    public static LinkedList<SimEvent> Events = new LinkedList<>();

    public static Comparator<SimEvent> rankComparator = (c1, c2) -> (c1._rank - c2._rank);
    public static PriorityQueue<SimEvent> eventQueue = new PriorityQueue(100, rankComparator);
    public static void AddSimEventsQueue(SimEvent e)
    {
        eventQueue.add(e);
//        Events.add(e);
//        OrderQueue();
    }

    public static SimEvent GetLowestRankEvent()
    {
        return eventQueue.poll();
       // return Events.pop();
    }

    private static void OrderQueue()
    {
        Events.sort(new Comparator<SimEvent>() {
            @Override
            public int compare(SimEvent o1, SimEvent o2) {
                return o1._rank.compareTo(o2._rank);
            }
        });
    }
}
