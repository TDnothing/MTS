using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS
{
    public class BusRider
    {
        private int _arrivalTime;
        private int _arrivalStopId;
        private int _destinationStopId;
        public int Count;

        public BusRider(int aTime, int aStop, int dStop, int count)
        {
            _arrivalTime = aTime;
            _arrivalStopId = aStop;
            _destinationStopId = dStop;
            Count = count;
        }


        public static int GetRideratStop(int stopid, int time)
        {
            Random r = new Random();
            int rInt = r.Next(-1, 1); //for ints
            return rInt;
        }

        public static int GetRiderOnBus(int stopid, int time)
        {
            Random r = new Random();
            int rInt = r.Next(-1, 1); //for ints
            return rInt;
        }

        public static int GetRiderOffBus(int stopid, int time)
        {
            Random r = new Random();
            int rInt = r.Next(-1, 1); //for ints
            return rInt;
        }
    }
}
