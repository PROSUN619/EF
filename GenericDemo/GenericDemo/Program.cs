using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.PrintType<Decimal>(1);
        }


        private static void PrintType<T>(T obj)
        {
            Console.WriteLine(obj.GetType().ToString());
        }
    }
}
