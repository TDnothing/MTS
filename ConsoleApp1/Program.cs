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
            s = Console.ReadLine();
            
            var currentDirectory = System.IO.Directory.GetCurrentDirectory();
            currentDirectory += "\\" + s;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "\\"+s);
            Console.WriteLine(currentDirectory);
            System.IO.StreamReader file =
                new System.IO.StreamReader(currentDirectory);
            Simulation sc = new Simulation();

            sc.CreateSimulation(file);

            Console.ReadLine();
            //ResetBus();           
        }
    }
}
