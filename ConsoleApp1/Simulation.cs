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
        //BusSystem BusSystem = new BusSystem();

        public void CreateSimulation(StreamReader file)
        {

            Readfile(file);
            for (int i = 0; i < 20; i++)
            {
                MoveNextBusButtonClick();
            }

            //ResetBus();
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
                BusSystem.CreateObject(result);
                System.Console.WriteLine(line);
                counter++;
            }

        }
        public void MoveNextBusButtonClick()
        {
          BusSystem.MoveNextBus();
        }

        public void ResetBus()
        {
           // BusSystem = new BusSystem();
            //Readfile(file);
        }


        //Bus b3 = new Bus(30, 61, 0, 0, 15, 100, 300, 20);
    }
}
