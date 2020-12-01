using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class Program
    {
        delegate double F2Delegate(double x1, double x2);

        private static double Func(double x1, double x2)
        {
            return 23 * Math.Pow(Math.Cos(Math.Pow(x1, 3) * Math.Pow(x2, 5)), 2) + 2 * x1;
        }

        private static double Acc(double r, double x)
        {
            return r + x;
        }

        private static void EnterData(out double a, out double b, out double dx)
        {
            Console.Write("Enter a:");
            a = double.Parse(Console.ReadLine());

            Console.Write("Enter b:");
            b = double.Parse(Console.ReadLine());

            Console.Write("Enter dx:");
            dx = double.Parse(Console.ReadLine());
        }

        private static void Tabulate(double a, double b, double dx, double init, F2Delegate func, F2Delegate acc)
        {
            double x = a;
            Console.WriteLine("Tabulate function");
            while (x <= b)
            {
                double x1 = x;
                double x2 = 3 * x;
                double y = func(x1, x2);
                Console.WriteLine("x={0}\t\ty={1}", x, y);
                if (x > a && x < b)
                {
                    init = acc(init, y);
                }
                x += dx;
            }
            Console.WriteLine("*****************");
            if (acc != null)
            {
                Console.WriteLine("Middle results");
                Console.WriteLine(init);
                Console.WriteLine("================");
            }
        }
        static void Main(string[] args)
        {
            EnterData(out double x1, out double x2, out double dx);
            Tabulate(x1, x2, dx, 0, Func, Acc);
            Console.ReadKey();
        }
    }
}