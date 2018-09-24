using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS
{
    public class Bus
    {
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

        public void UpdateBusPassenger(int offbus, int onbus)
        {
            _currentPassengers += (offbus + onbus);
        }

        public void UpdateBusLocation(int nextStopId)
        {
            Location = nextStopId;
        }

        public int Move(int rank)
        {
            BusRoute currentRoute = BusSystem.GetBusRoute(RouteId);

            int currentStopId = currentRoute.GetBusStopInfoByBusLocation(Location).Item2;
            var resut = currentRoute.GetBusStopInfoByBusLocation(Location + 1);
            int nextStopId = resut.Item2;
            int nextStopLocation = resut.Item1;

            BusStop currentStop = BusSystem.GetBusStop(currentStopId);
            BusStop nextStop = BusSystem.GetBusStop(nextStopId);

            //Bus left current stop
           // int offBus = BusRider.GetRiderOffBus(nextStopId, rank);
           // int onBus = BusRider.GetRiderOnBus(nextStopId, rank);

            //UpdateBusPassenger(offBus, onBus);
            UpdateBusLocation(nextStopLocation);
            //nextStop.UpdateStopRidersByBus(onBus, offBus);

            int time = BusStop.CalculateTimeWithSpeed(currentStop, nextStop, Speed);

            Console.WriteLine("b:{0}->s:{1}@{2}//p:{3}/f:{4}", Id,nextStopId,time+ rank, 0,0);
            return time;

        }
    }
}
