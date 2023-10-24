using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeApp
{
    static public class GetUserInput
    {
        public static double GetNumber(string message)
        {
            Console.Write(message);
            return double.Parse(Console.ReadLine()!);
        }

        public static char GetOperator(string message)
        {
            Console.Write(message);
            return char.Parse(Console.ReadLine()!);
        }

    }
}
