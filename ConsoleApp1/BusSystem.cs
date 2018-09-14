using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS
{
    public class BusSystem
    {
        public  List<Bus> Buses = new List<Bus>();
        public  List<BusStop> BusStops = new List<BusStop>();
        public  List<BusRoute> BusRoutes = new List<BusRoute>();
        public  List<SimEvent> Events = new List<SimEvent>();

        public  Bus GetBus(int id)
        {
            return Buses.FirstOrDefault(bus => bus.Id == id);
        }

        public  BusStop GetBusStop(int id)
        {
            return BusStops.FirstOrDefault(stop => stop.Id == id);
        }
        public  BusRoute GetBusRoute(int id)
        {
            return BusRoutes.FirstOrDefault(route => route.Id == id);
        }
        public  void AddSimEventsQueue(SimEvent e)
        {
            Events.Add(e);
            OrderQueue();
        }

        public SimEvent GetLowestRankEvent()
        {
            SimEvent simE = Events.FirstOrDefault();
            Events.RemoveAt(0);
            return simE;
        }

        private void OrderQueue()
        {
            Events.Sort((x, y) => x._rank.CompareTo(y._rank));
        }

        public void CreateObject(List<string> command)
        {
            switch (command[0])
            {
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
                    Events.Add(simEvent);
                    break;
                default:
                    break;
            }
        }
    }
}
