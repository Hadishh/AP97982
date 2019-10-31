using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S2
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length != 0 && (args[0] == "--size" || args[0] == "-s"))
            {
                try
                {
                    Console.WriteLine(SizeOfFiles(args[1]));
                }
                catch (Exception e)
                {
                    Console.WriteLine("I couldn't Find Directory! or it might be some ohter problem here!");
                }
            }
            else
            {
                Console.Write("Command Not Found!\nUsage : <--size or -s> <DirectoryPath>\n");

            }
        }
        public static long SizeOfFiles(string dirPath)
        {
            string[] directories = Directory.GetDirectories(dirPath);
            string[] files = Directory.GetFiles(dirPath);
            long size = 0;
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo info = new FileInfo(files[i]);
                size += info.Length;
            }
            for (int i = 0; i < directories.Length; i++)
                size += SizeOfFiles(directories[i]);
            return size;
        }
    }
}
