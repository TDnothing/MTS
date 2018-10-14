package MTS;

import javafx.scene.layout.Priority;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.LinkedList;
import java.util.List;


public class SimEventQueue {
    public static LinkedList<SimEvent> Events = new LinkedList<>();
    public static void AddSimEventsQueue(SimEvent e)
    {
        Events.add(e);
        OrderQueue();
    }

    public static SimEvent GetLowestRankEvent()
    {
        return Events.pop();
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
