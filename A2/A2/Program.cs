using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public static void AssignPi(out double PI){
            PI = 3.1459;
        }
        public static void Square(ref double x)
        {
            x = x * x;
        }
        public static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
        public static void Sum(out int sum, params int[] arrayNums)
        {
            sum = 0;
            foreach(var number in arrayNums)
            {
                sum += number;
            }
        }
        public static void Append(ref int[] array, int number)
        {
            List<int> newList = array.ToList();
            newList.Add(number);
            array = newList.ToArray();
        }
        public static void AbsArray(int [] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = Math.Abs(array[i]);
            }
        }
        public static void ArraySwap(int[] firstArray, int[] secondArray)
        {
            for(int i = 0; i < firstArray.Length; i++)
            {
                int temp = firstArray[i];
                firstArray[i] = secondArray[i];
                secondArray[i] = temp;
            }
        }
        public static void ArraySwap(ref int[] firstArray, ref int[] secondArray)
        {
            int[] tmpArray = firstArray;
            firstArray = secondArray;
            secondArray = tmpArray;
        }
    }
}
