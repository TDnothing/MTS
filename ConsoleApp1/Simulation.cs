using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS
{
    public class Simulation
    {
        BusSystem _busSystem = new BusSystem();
        System.IO.StreamReader file =
            new System.IO.StreamReader(@"D:\OMSCS\SoftwareArchDesign\test.txt");
        public void RunApp()
        {

            Readfile(file);
            MoveNextBus();
            MoveNextBus();
            MoveNextBus();
            MoveNextBus();
            MoveNextBus();
            MoveNextBus();
            MoveNextBus();
            MoveNextBus();
            MoveNextBus();
            ResetBus();
        }

        public void Readfile(StreamReader file)
        {
            file.DiscardBufferedData();
            file.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
            int counter = 0;
            string line;
            while ((line = file.ReadLine()) != null)
            {
                List<string> result = line.Split(',').ToList();
                _busSystem.CreateObject(result);
                System.Console.WriteLine(line);
                counter++;
            }

        }
        public void MoveNextBus()
        {
            var e1 = _busSystem.GetLowestRankEvent();
            //int id = e1.GetObjectId(e1);

            Bus currentBus = _busSystem.GetBus(e1._objectId);
            BusRoute currentRoute = _busSystem.GetBusRoute(currentBus.RouteId);

            int currentStopId = currentRoute.GetStopByBusLocation(currentBus.Location).Item2;
            var resut = currentRoute.GetStopByBusLocation(currentBus.Location + 1);
            int nextStopId = resut.Item2;
            int nextStopLocation = resut.Item1;

            BusStop currentStop = _busSystem.GetBusStop(currentStopId);
            BusStop nextStop = _busSystem.GetBusStop(nextStopId);

            //Bus Moving
            int time = BusStop.CalculateTimeWithSpeed(currentStop, nextStop, currentBus.Speed);
            SimEvent e0 = new SimEvent(time + e1._rank, "Move Bus", currentBus.Id);
            _busSystem.AddSimEventsQueue(e0);

            //Now the Bus arrived
            int offBus = BusRider.GetRiderOffBus(nextStopId, time);
            int onBus = BusRider.GetRiderOnBus(nextStopId, time);

            currentBus.UpdateBusPassenger(offBus, onBus);
            currentBus.UpdateBusLocation(nextStopLocation);
            nextStop.UpdateStopPassenger(onBus, offBus);

            Console.WriteLine("rank: {0}: move_bus ID: {1}", e1._rank, currentBus.Id);
            Console.WriteLine("the bus is at stop: {0} -  {1}", currentStop.Id, currentStop._name);
            Console.WriteLine("the bus is heading: {0} -  {1}", nextStop.Id, nextStop._name);
        }

        public void ResetBus()
        {
            _busSystem = new BusSystem();
            Readfile(file);
        }


        //Bus b3 = new Bus(30, 61, 0, 0, 15, 100, 300, 20);
    }
}
