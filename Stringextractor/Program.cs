using System;
using System.Diagnostics;

namespace Stringextractor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch bigtimer = new Stopwatch(); //timer for runtime statistics
            bigtimer.Start();




            bigtimer.Stop();
            TimeSpan rundurationraw = bigtimer.Elapsed;

            Console.WriteLine("Runtime " + rundurationraw);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
