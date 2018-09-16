using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace MTS
{
    public class Program
    {      
        static void Main(string[] args)
        {
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"D:\OMSCS\SAD\Assignment2\MTS\MTS\JavaPrototype\test_scenario.txt");
            Simulation sc = new Simulation();

            sc.CreateSimulation(file);


            //ResetBus();           
        }
    }
}
