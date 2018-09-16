using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS
{

    public class SimEvent
    {
       public int _rank;
        public string _type;
        public int _objectId;

        public SimEvent()
        { }
        public SimEvent(int rank, string type, int objectId)
        {
            _rank = rank;
            _type = type;
            _objectId = objectId;
        }

        public void CreateSimEvent(int rank, string type, int objectId)
        {
            _rank = rank;
            _type = type;
            _objectId = objectId;
        }
       
        public void ExecuteEvent()
        {
            Bus currentBus = BusSystem.GetBus(_objectId);
            Console.WriteLine("rank: {0}: move_bus ID: {1}", _rank, currentBus.Id);
            int NextRank = currentBus.Move(_rank);
            SimEvent nextEvent = new SimEvent(NextRank + _rank,"move bus",currentBus.Id);
            SimEventQueue.AddSimEventsQueue(nextEvent);
        }

        public int GetObjectId(SimEvent e)
        {
            return e._objectId;
        }



    }
}
