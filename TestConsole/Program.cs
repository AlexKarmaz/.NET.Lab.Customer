using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer(1, "Alex", "Karmaz");
            Customer c2 = new Customer(2, "Dmitry", "Ignatenko");
            Customer c3 = new Customer(1, "dddsds", "dsds");


            Console.WriteLine($"Equals by id c1.Equals(c2) {c1.Equals(c2)}");
            Console.WriteLine($"Equals by id c1.Equals(c3) {c1.Equals(c3)}");
            Console.WriteLine($"operator <  {c1 < c2}");
            Console.WriteLine($"operator >  {c1 > c2}");

            Console.ReadKey();
        }
    }
}
