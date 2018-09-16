using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;


namespace MTS
{
    public class BusStop: Coordinate
    {
        public int Id;
        public string _name;
        private int _riders;
        private static int nextID = 1000;
        private double Latitude { get; set; }
        private double Longitude { get; set; }
        public BusStop(int ID, string name, int riders, double latitude, double longitude)
        {
            Id = ID;
            _name = name;
            _riders = riders;
            Latitude = latitude;
            Longitude = longitude;
        }



        public static int CalculateTimeWithSpeed(BusStop stopA, BusStop stopB, int currentBusSpeed)
        {
            
            double distance = 70.0 * Math.Sqrt(Math.Pow((stopA.Latitude -
            stopB.Latitude), 2) + Math.Pow((stopA.Longitude - stopB.Longitude), 2));

            int travel_time = 1 + (Convert.ToInt32(distance) * 60 / currentBusSpeed);
            return travel_time;
        }

        public void UpdateStopRidersByBus(int onbus, int offbus)
        {
            _riders += (onbus + offbus);
        }

        public void UpdateStopRidersByTime(int time)
        {

        }
    }
}
