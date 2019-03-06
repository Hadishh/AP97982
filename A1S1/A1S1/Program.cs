using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A1S1
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public static int CaculateLength(string str)
        {
            return str.Length;
        }
        public static int LetterCount(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
                if (char.IsLetter(str[i]))
                    count++;
            return count;
        }

        public static int LineCount(string str)
        {
            //For Empty strings
            if (str == "" || str == null)
                return 0;
            return str.Split('\n').Length;
        }

        public static int FileLineCount(string filePath)
        {
            return File.ReadAllLines(filePath).Length;
        }

        public static string[] ListFiles(string dirPath)
        {
            //Not Sroted List
            List<string> files = Directory.GetFiles(dirPath, "*.txt").ToList();
            //Sorted List Ordered by Name
            files = files.OrderBy(Path.GetFileName).ToList();
            int[] Numbers = new int[16];
            try
            {
                
                for(int i = 0; i < files.Count; i++)
                {
                    //It's .Txt File ! 4 characters to numeric part!
                    int index = files[i].Length - 5;
                    if (char.IsDigit(files[i][index]))
                    {
                        int j = index;
                        string digitPart = "";
                        while (char.IsDigit(files[i][j])){
                            digitPart = files[i][j] + digitPart;
                            j--;
                        }
                        Numbers[i] = int.Parse(digitPart);
                    }
                    if (Numbers[i] == i)
                        continue;
                    string temp = files[i];
                    files[i] = files[Numbers[i]];
                    files[Numbers[i]] = temp;
                    i = 0;
                }
               
            }
            catch(Exception e)
            {
                //Give Some Errors
            }
            for(int i = 0; i < Numbers.Length; i++)
            {
                
            }
            return files.ToArray();
        }

        public static double FileSize(string filePath)
        {
            return File.ReadAllText(filePath).Length;
        }
    }
}
