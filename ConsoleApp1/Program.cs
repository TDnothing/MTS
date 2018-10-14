using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            string s = String.Empty;
            

            System.IO.StreamReader file =
                new System.IO.StreamReader(@"D:\OMSCS\SAD\Assignment5\test0_instruction_demo.txt");
            Simulation sc = new Simulation();

            sc.CreateSimulation(file);

            Console.ReadLine();
            //ResetBus();           
        }
    }
}
