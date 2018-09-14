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
    }
}
