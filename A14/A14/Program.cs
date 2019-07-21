using System;
using System.Linq;
namespace A14
{
    abstract class A { public virtual void Do() => Console.Write(1); }
    class B : A { public override void Do() => Console.Write(2); }
    class C : B { public virtual void Do() => Console.Write(3); }
    class D : A { public override void Do() => Console.Write(5); }
    class E : A { }
    class F
    {
        static void Main(string[] args)
        {
            G g = new G();
            Console.WriteLine();
        }
    }
    public class G
    {
        public int a;
        public G() : this(5) { }
        private G(int a)
        {
            a = 5;
        }
    }
    public class Program
    {
        //static void Main(string[] args)
        //{
        //    //RunCalculator(() => Console.ReadKey().KeyChar, Console.Clear);
        //    var data = new int[] { 2, 3, 5, 1, -2, 5, 7 };
        //    var data5 = data.Join(
        //        data.Select(x => Math.Abs(x)),
        //        x => x, y => y, (x, y) => x + y);
        //    Console.WriteLine(string.Join(",", data5));
        //    Console.WriteLine("=========");
        //    Console.WriteLine(string.Join(",",data.OrderByDescending((d) => Math.Abs(d))));
        //}

        public static Calculator RunCalculator(Func<char> GetKey, Action clearScreen)
        {
            Calculator calc = new Calculator(clearScreen);
            while (true)
            {
                calc.PrintDisplay();
                char key = GetKey();
                switch (key)
                {
                    case '.':
                        calc.EnterPoint();
                        break;
                    case '0':
                        calc.EnterZeroDigit();
                        break;
                    case '=':
                    case (char)ConsoleKey.Enter:
                        calc.EnterEqual();
                        break;
                    case (char)ConsoleKey.Escape:
                        calc.Clear();
                        break;
                    case var c when c != '0' && char.IsDigit(c):
                        calc.EnterNonZeroDigit(c);
                        break;
                    case var c when Calculator.Operators.ContainsKey(c):
                        calc.EnterOperator(c);
                        break;
                    case 'q':
                        return calc;
                }
            }
        }
    }
}
