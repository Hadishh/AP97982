using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A8
{
    class Program
    {
        static void Main(string[] args)
        {
            Human dwarf = new Human("Amir", "Amiri", new DateTime(2010, 9, 3), 2.5);
            Console.WriteLine(dwarf.FirstName.GetHashCode());
            Console.WriteLine(dwarf.LastName.GetHashCode());
            Console.WriteLine(dwarf.Height.GetHashCode());
            Console.WriteLine(dwarf.BirthDate.GetHashCode());
            Console.WriteLine(dwarf.GetHashCode());
            //93033477
        }
    }
}
