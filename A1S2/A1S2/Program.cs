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
        }
        public static long SizeOfFiles(string dirPath)
        {
            string[] directories = Directory.GetDirectories(dirPath);
            string[] files = Directory.GetFiles(dirPath);
            long size = 0;           
            for(int i = 0; i < files.Length; i++)
            {
                FileInfo info = new FileInfo(files[i]);
                size += info.Length;
            }
            for(int i = 0; i < directories.Length; i++)
            {
                size += SizeOfFiles(directories[i]);
            }
            return size;
        }
    }
}
