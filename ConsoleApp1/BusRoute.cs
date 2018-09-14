﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTS
{
    public class BusRoute
    {
        public int Id;
        private int _number;
        public string _name;
        private List<int> _busStops = new List<int>();

        public BusRoute(int id, int number, string name)
        {
            Id = id;
            _name = name;
            _number = number;
        }

        public void ExtendRoute(int stopid)
        {
            _busStops.Add(stopid);
        }

        public Tuple<int, int> GetStopByBusLocation(int location)
        {
            if (location >= _busStops.Count) return Tuple.Create(0, _busStops[0]);
            else return Tuple.Create(location, _busStops[location]);
        }
    }
}
