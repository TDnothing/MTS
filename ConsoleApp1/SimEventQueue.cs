using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS
{
    public class SimEventQueue
    {
        public static List<SimEvent> Events = new List<SimEvent>();

        public static void AddSimEventsQueue(SimEvent e)
        {
            Events.Add(e);
            OrderQueue();
        }

        public static SimEvent GetLowestRankEvent()
        {
            SimEvent simE = Events.FirstOrDefault();
            Events.RemoveAt(0);
            return simE;
        }

        private static void OrderQueue()
        {
            Events.Sort((x, y) => x._rank.CompareTo(y._rank));
        }
    }
}
