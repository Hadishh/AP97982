using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            int[] numbers = new int[17];
            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    //It's "*.Txt" File ! 4 characters to numeric part!
                    int index = files[i].Length - 5;
                    if (char.IsDigit(files[i][index]))
                    {
                        int j = index;
                        string digitPart = "";
                        while (char.IsDigit(files[i][j]))
                        {
                            digitPart = files[i][j] + digitPart;
                            j--;
                        }
                        numbers[i] = int.Parse(digitPart);
                    }
                    if (numbers[i] == i)
                        continue;
                    string temp = files[i];
                    files[i] = files[numbers[i]];
                    files[numbers[i]] = temp;
                    i = 0;
                }
            }
            catch (Exception e)
            {
                string exception = "Process terimnated due an error : " + e.Message;
                throw new Exception(exception);
            }
            return files.ToArray();
        }

        public static double FileSize(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int linesCount = 0;
            for (int i = 0; i < lines.Length; i++)
                linesCount += lines[i].Length;
            return linesCount;
        }
    }
}
