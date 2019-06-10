using System;
using System.Collections.Generic;
using System.IO;

namespace E2
{
    public class FullName
    {
        public string FirstName;
        public string LastName;

        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is FullName))
                return false;
            FullName other = obj as FullName;
            return other.FirstName == this.FirstName && other.LastName == this.LastName;
        }
    }

    public static class Basics
    {
        public static int CalculateSum(string expression)
        {
            string[] numbers = expression.Split('+');
            int sum = 0;
            foreach(var number in numbers)
            {
                if (number == string.Empty)
                    throw new InvalidDataException();
                try
                {
                    sum += int.Parse(number);
                }
                catch(FormatException)
                {
                    throw;
                }
            }
            return sum;
        }

        public static bool TryCalculateSum(string expression, out int value)
        {

            string[] numbers = expression.Split('+');
            int sum = 0;
            value = 0;
            foreach (var number in numbers)
            {
                if (number == string.Empty)
                    return false;
                try
                {
                    sum += int.Parse(number);
                }
                catch (FormatException)
                {
                    return false;
                }
            }
            value = sum;
            return true;
        }

        /// <summary>
        /// {\displaystyle 1\,-\,{\frac {1}{3}}\,+\,{\frac {1}{5}}\,-\,{\frac {1}{7}}\,+\,{\frac {1}{9}}\,-\,\cdots \,=\,{\frac {\pi }{4}}.}
        /// </summary>
        /// <returns></returns>
        public static int PIPrecision()
        {
            double PI = Math.Round(Math.PI, 7);
            double currentValue = 0f;
            int steps = 0;
            //int currentInt = 1;
            while(Math.Round(Math.Abs(4 * currentValue - PI), 7 ) != 0)
            {
                currentValue += Math.Pow(-1, steps) * (1 / (double)(2 * steps + 1));
                steps++;
            }
            return steps;
        }

        public static int Fibonacci(this int n)
        {
            if (n == 0 || n == 1)
                return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public static void RemoveDuplicates<T>(ref T[] list)
        {
            List<T> newList = new List<T>();
            foreach (var item in list)
            {
                if (!Contains(newList, item))
                    newList.Add(item);
            }
            list = newList.ToArray();
        }

        private static bool Contains<T>(List<T> list, T lookup)
        {
            foreach (var item in list)
                if (item.Equals(lookup))
                    return true;
            return false;
        }
    }
}