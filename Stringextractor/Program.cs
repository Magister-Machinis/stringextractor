using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Stringextractor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch bigtimer = new Stopwatch(); //timer for runtime statistics
            bigtimer.Start();
            string root = Path.GetFullPath(@".\");
            List<string> filelist = Directory.GetFileSystemEntries(root, "*", SearchOption.TopDirectoryOnly).ToList();
            for(int count = 0; count < filelist.Count -1; count ++)
            {

            }



            bigtimer.Stop();
            TimeSpan rundurationraw = bigtimer.Elapsed;

            Console.WriteLine("Runtime " + rundurationraw);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        static void FormatHex(string Hex, string filepath)
        {
            string targetpath = Path.Combine(Path.GetDirectoryName(filepath), ("Stringsof" + Path.GetFileName(filepath) + ".txt"));
            using (StreamWriter output = File.CreateText(targetpath))
            {
                output.WriteLine(Hex);
            }
        }

        static string ReturnHex(string filepath)
        {
            byte[] bytes = File.ReadAllBytes(filepath);
            string hex = BitConverter.ToString(bytes);
            return hex.Replace("_", "");
        }
    }
}
