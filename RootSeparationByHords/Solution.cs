using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RootSeparationByHords
{

	static class Solution
	{
		public static decimal firstFunction(decimal x)
		{

			return 3m * x - Convert.ToDecimal(Math.Cos(Convert.ToDouble(x))) - 1m;
		}
		public static decimal secondFunction(decimal x)
		{

			return x * x * x + 0.2m * x * x + 0.5m * x - 1.2m;
		}

		static void Main(string[] args)
		{
			decimal count = 0m;
			decimal step = 0.1m;
			decimal passage_a = 0.6m;
			decimal passage_b = 0.8m;
			Console.WriteLine("1)");
			Console.WriteLine("\tn\txn\th");
			decimal x = step;
			for (int i = 0; Convert.ToDecimal(Math.Abs(
					Convert.ToDouble(x - passage_a))) > 0.001m;
						i++)
			{
				if (i == 5)
				{
					break;
				}
				x = passage_a;
				step = firstFunction(passage_a) /
					(firstFunction(passage_b) - firstFunction(passage_a))
					* (passage_b - passage_a);
				Console.WriteLine("\t{0}\t{1:0.0000}\t{2:0.0000}", count, passage_a, step);
				passage_a -= step;
				count++;
			}

			Console.WriteLine("x={0:0.0000}", passage_a);
			Console.WriteLine();
			Console.WriteLine("2)");
			passage_a = -10m;
			passage_b = 10m;
			step = 0.1m;
			count = 0m;
			x = step;
			Console.WriteLine("n      xn      h");
			for (int i = 0; Convert.ToDecimal(Math.Abs(
					Convert.ToDouble(x - passage_b))) > 0.001m;
						i++)
			{
				if (i == 10)
				{
					break;
				}
				step = secondFunction(passage_a) /
					(secondFunction(passage_b) - secondFunction(passage_a))
					* (passage_b - passage_a);
				Console.WriteLine("\t{0}\t{1:0.0000}\t{2:0.0000}", count, passage_b, step);
				x = passage_b;
				passage_b = passage_a - step;
				count++;
			}

			Console.WriteLine("x={0:0.0000}", passage_b);
			Console.ReadLine();



		}
	}
}