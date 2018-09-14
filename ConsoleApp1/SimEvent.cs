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

        public void ExecuteEvent()
        {
            if (_type == "Move Bus")
                GetObjectId(this);

        }

        public int GetObjectId(SimEvent e)
        {
            return e._objectId;
        }



    }
}
