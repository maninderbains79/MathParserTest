using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParserApp
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                MathParserSimpleMath SY = new MathParserSimpleMath();
                String s = "3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3";
                Console.WriteLine("input: {0}", s); Console.WriteLine();
                List<String> ss = s.Split(' ').ToList();
                SY.DebugRPNSteps += new MathParserBase<double, string>.DebugRPNDelegate(SY_DebugRPNSteps);
                SY.DebugResSteps += new MathParserBase<double, string>.DebugResDelegate(SY_DebugResSteps);
                Double res = SY.Execute(ss, null);

                bool ok = res == 3.0001220703125;
                Console.WriteLine("input: {0} = {1} {2}", s, res, (ok ? "Ok" : "Error"));
                Console.ReadKey();
            }
            {
            }
        }

        static void SY_DebugRPNSteps(List<object> inter, List<char> opr)
        {
            Console.Write("RPN ");
            foreach (object o in inter)
                Console.Write("{0} ", o.ToString());
            foreach (char o in opr)
                Console.Write("{0} ", o.ToString());
            Console.WriteLine();
        }

        static void SY_DebugResSteps(List<object> res, List<double> var)
        {
            Console.Write("RPN ");
            foreach (object o in res)
                Console.Write("{0} ", o.ToString());
            Console.Write("\n= ");
            foreach (double o in var)
                Console.Write("{0} ", o.ToString());
            Console.WriteLine();
        }

    }
}
