using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

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
            int counter = 0;
            string MyName = (Process.GetCurrentProcess()).MainModule.FileName;
            Console.WriteLine(MyName);
            for (int count = 0; count < filelist.Count -1; count ++)
            {
                if (Path.GetFileName(filelist[count]) != MyName)
                {
                    FileAttributes atr = File.GetAttributes(filelist[count]);
                    if (atr.HasFlag(FileAttributes.Directory) == false)
                    {
                        counter++;
                        FormatHex(ReturnHex(filelist[count]), filelist[count]);
                    }
                }
            }



            bigtimer.Stop();
            TimeSpan rundurationraw = bigtimer.Elapsed;
            Console.WriteLine("Files processed: " + counter);
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
            hex = hex.Replace("-", "");
            hex = "Hex Code: \r\n" + hex;
            hex += "\r\n\r\n ASCII: \r\n";
            hex += Encoding.ASCII.GetString(bytes);
            hex += "\r\n\r\n Unicode: \r\n";
            hex += Encoding.Unicode.GetString(bytes);
            hex += "\r\n\r\n UTF8: \r\n";
            hex += Encoding.UTF8.GetString(bytes);
            return hex;
        }
    }
}
