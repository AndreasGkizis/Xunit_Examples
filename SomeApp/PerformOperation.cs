using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeApp
{
	public static class PerformOperation
	{
		public static double RunOp(double num1, char operation, double num2)
		{
			switch (operation)
			{
				case '+':
					return Add(num1, num2);
				case '-':
					return Subtract(num1, num2);
				case '*':
					return Multiply(num1, num2);
				case '/':
					if (num2 != 0)
						return Divide(num1, num2);
					else
					{
						throw new DivideByZeroException("Division by zero is not allowed.");
					}
				default:
					throw new ArgumentException("Invalid operator");
			}
		}

		private static double Add(double num1, double num2)
		{
			return num1 + num2;
		}
		private static double Subtract(double num1, double num2)
		{
			return num1 - num2;
		}
		private static double Divide(double num1, double num2)
		{
			return num1 / num2;
		}
		private static double Multiply(double num1, double num2)
		{
			return num1 * num2;
		}
	}
}
