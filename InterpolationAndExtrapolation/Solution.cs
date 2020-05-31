using System;

namespace InterpolationAndExtrapolation
{
	class Solution
	{
		static void Main(string[] args)
		{
			////Здесь мы объявляем переменные нашего будущего алгоритма
			//decimal x_1, x_2, x_3, x_4, t1, t2, t3, t4;
			//decimal n = 30m;
			//decimal h = 0.5m;

			//   // Ссылки на массивы типа double, в которых будут храниться данные таблицы f(x)
			//decimal[] arrayOfArguments, arrayOfFunctions;

			//// Задаём размер статических массивов и их значение
			//arrayOfArguments = new double[13] {1.50m, 1.55m, 1.60m, 1.65m, 1.70m, 1.75m, 1.80m, 1.85m, 1.90m, 1.95m, 2.00m, 2.05m, 2.10m };
			//arrayOfFunctions = new double[13] { 15.132m, 17.422m, 20.393m, 32.812m, 37.857m, 43.189m, 48.689m, 54.225m, 59.653m,69.55m };


			//// Вводим значения таблицы f(x)

			////Console.WriteLine("Enter  table's arguments");
			////for (int counter_1 = 0; counter_1 < arrayOfArguments.Length; counter_1++)
			////{
			////	Console.Write("Enter element number [{0}]   ", counter_1 + 1);
			////	arrayOfArguments[counter_1] = double.Parse(Console.ReadLine());
			////}
			////Console.WriteLine("Enter  table's functions");
			////for (int counter_2 = 0; counter_2 < arrayOfArguments.Length; counter_2++)
			////{
			////	Console.Write("Enter element number [{0}]", counter_2 + 1);
			////	arrayOfFunctions[counter_2] = double.Parse(Console.ReadLine());
			////}

			//// Показываем таблицу
			//Console.WriteLine("X \t Y(X)");
			//for (int i = 0; i < 13; i++)
			//{
			//	Console.Write("{0} \t {1} \n", arrayOfArguments[i], arrayOfFunctions[i]);
			//}

			//t1 = (x_1 - X(1)) / h;
			//t2 = (x_2 - X(1)) / h;
			//t3 = (x_3 - X(1)) / h;
			//t4 = (x_4 - X(1)) / h;


			decimal[] arrayOfArguments = new decimal[] { 1.50m, 1.55m, 1.60m, 1.65m, 1.70m, 1.75m, 
					1.80m, 1.85m, 1.90m, 1.95m, 2.00m, 2.05m, 2.10m };
				decimal[] arrayOfFunctions = new decimal[] { 15.132m, 17.422m, 20.393m, 
					23.994m, 28.16m, 32.812m, 37.857m, 43.189m, 48.689m, 54.225m, 59.653m,
					64.817m, 69.55m };
				decimal[] argument = new decimal[30];
				decimal length_1 = arrayOfArguments.Length;
				decimal length_2 = arrayOfFunctions.Length;
				decimal xytables_middle = Math.Round(length_1 / 2);
				for (int i = 0; i < 30; i++)
				{
				argument[i] = 1.83m + (i + 1) * 0.003m;
				//Console.WriteLine(argument[i]);
			}

				decimal[] delta_first = new decimal[arrayOfFunctions.Length - 1];
				decimal delta_first_middle = Math.Round(delta_first.Length / 2.00m);
				for (int i = 0; i < delta_first.Length; i++)
				{
					delta_first[i] = arrayOfFunctions[i + 1] - arrayOfFunctions[i];
				//Console.WriteLine(delta_first[i]);
			}

				decimal[] delta_second = new decimal[arrayOfFunctions.Length - 2];
				decimal delta_second_middle = Math.Round(delta_second.Length / 2.00m);
				for (int i = 0; i < delta_second.Length; i++)
				{
					delta_second[i] = delta_first[i + 1] - delta_first[i];
				//Console.WriteLine(delta_second[i]);
			}

				decimal[] delta_third = new decimal[arrayOfFunctions.Length - 3];
				decimal delta_third_middle = Math.Round(delta_third.Length / 2.00m);
				for (int i = 0; i < delta_third.Length; i++)
				{
					delta_third[i] = delta_second[i + 1] - delta_second[i];
				//Console.WriteLine(delta_third[i]);
			}

			gaussian_1(argument, xytables_middle, arrayOfArguments, arrayOfFunctions, delta_first, delta_second,
				delta_third, delta_first_middle, delta_second_middle, delta_third_middle);
			

			bessel(argument, xytables_middle, arrayOfArguments, arrayOfFunctions, delta_first, delta_second,
					delta_third, delta_first_middle, delta_second_middle, delta_third_middle);
			

			stirling(argument, xytables_middle, arrayOfArguments, arrayOfFunctions, delta_first, delta_second,
					delta_third, delta_first_middle, delta_second_middle, delta_third_middle);
			

			gaussian_2(argument, xytables_middle, arrayOfArguments, arrayOfFunctions, delta_first, delta_second,
					delta_third, delta_first_middle, delta_second_middle, delta_third_middle);
			
		}
		private static void gaussian_1(decimal[] argument, decimal xytables_middle,
			decimal[] arrayOfArguments, decimal[] arrayOfFunctions,
			decimal[] delta_first, decimal[] delta_second, decimal[] delta_third,
			 decimal delta_first_middle, decimal delta_second_middle, decimal delta_third_middle)
		{
			Console.WriteLine("x = 1.83 - 0,003n;\n1)First Gaussian formula:");
			for (int i = 0; i < 30; i++)
			{
				decimal t = (argument[i] - arrayOfArguments[Convert.ToInt32(xytables_middle)]) / 0.05m;
				decimal y = arrayOfFunctions[Convert.ToInt32(xytables_middle)] +
					t * delta_first[Convert.ToInt32(delta_first_middle)] +
					t * (t - 1.00m) * delta_second[Convert.ToInt32(delta_second_middle - 1)] / 2.00m +
					(t + 1.00m) * t * (t - 1.00m) / 6.00m * delta_third[Convert.ToInt32(delta_third_middle - 1)];
				Console.WriteLine("x ={0} \t y = {1}\n", argument[i], y);
			}
		}
			private static void bessel(decimal[] argument, decimal xytables_middle,
				decimal[] arrayOfArguments, decimal[] arrayOfFunctions,
				decimal[] delta_first, decimal[] delta_second, decimal[] delta_third,
				 decimal delta_first_middle, decimal delta_second_middle, decimal delta_third_middle)
			{
				Console.WriteLine("\n2)Bessel's formula :");
				for (int i = 0; i < 30; i++)
				{
					decimal t = (argument[i] - arrayOfArguments[Convert.ToInt32(xytables_middle)]) / 0.05m;
					decimal y = ((arrayOfFunctions[Convert.ToInt32(xytables_middle)] + 
					arrayOfFunctions[Convert.ToInt32(xytables_middle - 1)]) / 2m +
					(t - 0.5m) * delta_first[Convert.ToInt32(delta_first_middle)] +
					t * (t - 1m) * (delta_second[Convert.ToInt32(delta_second_middle - 1)] +
					delta_second[Convert.ToInt32(delta_second_middle)]) / 4m)+5m;
					Console.WriteLine("x = {0} \t y = {1}\n", argument[i], y);
				}
			}

		private static void stirling(decimal[] argument, decimal xytables_middle,
			decimal[] arrayOfArguments, decimal[] arrayOfFunctions,
			decimal[] delta_first, decimal[] delta_second, decimal[] delta_third,
			decimal delta_first_middle, decimal delta_second_middle, decimal delta_third_middle)
		{
			Console.WriteLine("\n3)Stirling's formula:");
			for (int i = 0; i < 30; i++)
			{
				decimal t = (argument[i] - arrayOfArguments[Convert.ToInt32(xytables_middle)]) / 0.05m;
				decimal y = arrayOfFunctions[Convert.ToInt32(xytables_middle)] + 
					t * (delta_first[Convert.ToInt32(delta_first_middle - 1)] + delta_first[Convert.ToInt32(delta_first_middle)]) / 2m + t / 2m * delta_second[Convert.ToInt32(delta_second_middle - 1)] + t * (t * t - 1m) * (delta_third[Convert.ToInt32(delta_third_middle - 2)] + delta_second[Convert.ToInt32(delta_second_middle - 1)]) / 12m;
				Console.WriteLine("x = {0} \t y = {1}\n", argument[i], y);
			}
		}
		private static void gaussian_2(decimal[] argument, decimal xytables_middle,
			decimal[] arrayOfArguments, decimal[] arrayOfFunctions,
			decimal[] delta_first, decimal[] delta_second, decimal[] delta_third,
			decimal delta_first_middle, decimal delta_second_middle, decimal delta_third_middle)
		{
			Console.WriteLine("\n4)Second Gaussian formula");
			for (int i = 0; i < 30; i++)
			{
				decimal t = (argument[i] - arrayOfArguments[Convert.ToInt32(xytables_middle)]) / 0.05m;
				decimal y = arrayOfFunctions[Convert.ToInt32(xytables_middle)] +
					t * delta_first[Convert.ToInt32(delta_first_middle - 1)] +
					t * (t + 1m) / 2m * delta_second[Convert.ToInt32(delta_second_middle - 1)] +
					(t + 1) * t * (t - 1m) / 6m * delta_third[Convert.ToInt32(delta_third_middle - 2)];
				Console.WriteLine("x = {0} \t y = {1}\n", argument[i], y);
			}
		}
	}
	}

