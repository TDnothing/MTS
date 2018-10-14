using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS
{
    public class BusSystem
    {
        public static List<Bus> Buses = new List<Bus>();
        public static List<BusStop> BusStops = new List<BusStop>();
        public static List<BusRoute> BusRoutes = new List<BusRoute>();
        public static int BusSystemLogicalTime;
        
        public static Dictionary<int, Bus> HBus = new Dictionary<int, Bus>();

        public static Bus GetHBus(int busid)
        {
            if (HBus.ContainsKey(busid))
            {
                return HBus[busid];
            }
            return null;
        }

        public static Bus GetBus(int id)
        {
            return Buses.FirstOrDefault(bus => bus.Id == id);
        }

        public static BusStop GetBusStop(int id)
        {
            return BusStops.FirstOrDefault(stop => stop.Id == id);
        }
        public static BusRoute GetBusRoute(int id)
        {
            return BusRoutes.FirstOrDefault(route => route.Id == id);
        }

        public static void MoveNextBus()
        {
            var e1 = SimEventQueue.GetLowestRankEvent();
            e1.ExecuteEvent();
            //int id = e1.GetObjectId(e1);

            
        }

        public static void CreateObject(List<string> command)
        {
            switch (command[0])
            {
                case "add_depot":
//                    BusStop busStop0 = new BusStop(Convert.ToInt32(command[1]), command[2],0, Convert.ToDouble(command[3]), Convert.ToDouble(command[4]));
//                    BusStops.Add(busStop0);
                    break;
                case "add_bus":
                    Bus bus1 = new Bus(Convert.ToInt32(command[1]), Convert.ToInt32(command[2]), Convert.ToInt32(command[3]), Convert.ToInt32(command[4]), Convert.ToInt32(command[5]),
                        Convert.ToInt32(command[6]), Convert.ToInt32(command[7]), Convert.ToInt32(command[8]));
                    Buses.Add(bus1);
                    break;
                case "add_stop":
                    BusStop busStop1 = new BusStop(Convert.ToInt32(command[1]), command[2], Convert.ToInt32(command[3]), Convert.ToDouble(command[4]), Convert.ToDouble(command[5]));
                    BusStops.Add(busStop1);
                    break;
                case "add_route":
                    BusRoute busRoute1 = new BusRoute(Convert.ToInt32(command[1]), Convert.ToInt32(command[2]), command[3]);
                    BusRoutes.Add(busRoute1);
                    break;
                case "extend_route":
                    BusRoute targetRoute = GetBusRoute(Convert.ToInt32(command[1]));
                    targetRoute?.ExtendRoute(Convert.ToInt32(command[2]));
                    break;
                case "add_event":
                    SimEvent simEvent = new SimEvent(Convert.ToInt32(command[1]), command[2], Convert.ToInt32(command[3]));
                    SimEventQueue.AddSimEventsQueue(simEvent);
                    break;
                default:
                    break;
            }
        }
    }
}
