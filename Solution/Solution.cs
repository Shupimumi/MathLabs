using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    class Solution
    {
        static double FunctionForSecondMethod(double x)
        {
            return 3 * Math.Pow(x, 4) + 4 * Math.Pow(x, 3) - 12 * Math.Pow(x, 2) + 1;
        }

        static double FunctionForFourthMethod(double x)
        {
            return x * x * Math.Cos(2 * x) + 1;
        }
        static void Main(string[] args)
        {
			Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
			Dictionary<double, char> markOfFunction = new Dictionary<double, char>();
            int solutionsCount = 0;
            double firstElement = 0;
            double secondElement = 0;
            const double exponent = 0.01;
            string function_1 = "exp^(-2*x)-2*x+1";
            string derivativeFunction_1 = "-2-2*exp^(-2*x)";
            const string format = "{0, 4}{1, 10:0.###}{2, 10:0.###}{3, 16:0.###}{4, 12:0.###}";
            double[] solutions = {-2,-1.5};
            double[] samplesSolutions = { -4, 0, 1 };

            firstMethod(function_1, derivativeFunction_1);
            secondMethod(samplesSolutions, markOfFunction, solutionsCount,
                firstElement, secondElement, exponent, format, secondElement, firstElement);
            thirdMethod(solutions);
            fourthMethod(solutions, firstElement, secondElement, markOfFunction, format, exponent);
            Console.ReadLine();
        }
        static void firstMethod(string function_1, string derivativeFunction_1)
		{
            Console.WriteLine("\n\n\n\n\n\t1) The equation is f(x) = {0}.\n\t Derivative is f'(x) = {1}.", function_1,
                derivativeFunction_1);
            Console.WriteLine("\n\tFinding of Derivative's roots:\n");
            Console.WriteLine("\t-2-2*exp^(-2*x) = 0");
            Console.WriteLine("\t-2*exp^(-2*x) = 2");
            Console.WriteLine("\t(-2*exp^(-2*x))/2 = 2/2");
            Console.WriteLine("\texp^(-2*x) = -1");
            Console.WriteLine("\tMaking replacement...");
            Console.WriteLine("\texp^(-2*x) = V");
            Console.WriteLine("\tV = -1");
            Console.WriteLine("\tBack replacement");
            Console.WriteLine("\texp^(-2*x) = V");
            Console.WriteLine("\tx = -(log(V))/2");
            Console.WriteLine("\tFinal calculation:");
            Console.WriteLine("\tx1 = -(log(-1))/log(exp^(-2)) = -i*Pi/2");
            Console.WriteLine("\tx2 = +i*Pi/2");
            Console.WriteLine("\tAnswer is x1 = -i*Pi/2; x2 =+i*Pi/2 .");      
        }

        static void secondMethod(double[] samplesSolutions, Dictionary<double, char> 
            markOfFunction, int solutionsCount, double a, double b, double e, string format,
            double secondElement, double firstElement)
		{
            Console.WriteLine("\n\n\n\n2) The equation is - f(x) = x^4 + 4*x^3 - 8*x^2 - 17\nDerivative is f'(x) = 4*x^3 + 12*x^2 - 16*x");
            Console.WriteLine("\nRoots finding ....\n");
            Console.WriteLine("x^3 + 3*x^2 - 4*x");
            Console.WriteLine("x(x^2 + 3*x - 4) = 0\n");
            for (int i = 0; i < samplesSolutions.Length; i++)
                Console.WriteLine($"x{i + 1} = {samplesSolutions[i],2}");
            Console.WriteLine("\nMarks table:");
            for (int i = 0; i < samplesSolutions.Length; i++)
            {
                char mark;
                if (i == 0)
                {
                    double x = samplesSolutions[0] - 1;
                    if (FunctionForSecondMethod(x) < 0)
                    {
                        mark = '-';
                    }
                    else mark = '+';
                    markOfFunction.Add(x, mark);
                }
				if (FunctionForSecondMethod(samplesSolutions[i]) < 0)
				{
                    mark = '-';
                }
                else mark = '+';                 
                markOfFunction.Add(samplesSolutions[i], mark);
                if (i == samplesSolutions.Length - 1)
                {
                    double x = samplesSolutions[i] + 1;
					if (FunctionForSecondMethod(x) < 0)
					{
                        mark = '-';
                    }else mark = '+';             
                    markOfFunction.Add(x, mark);
                }
            }

            foreach (var item in markOfFunction)
            {
                Console.Write($"{item,10}");
            }
            for (int i = 0; i < markOfFunction.Count - 1; i++)
            {
                if (markOfFunction.ElementAt(i).Value != markOfFunction.ElementAt(i + 1).Value)
                    solutionsCount++;
            }

            Console.WriteLine("\nThe number of real roots of the equation " + solutionsCount);
            a = markOfFunction.ElementAt(0).Key;
            b = markOfFunction.ElementAt(1).Key;
            Console.WriteLine($"\n We clarifying one of the roots by sample method,\n Our root is x1\n gap is [{a}, {b}]:\n");
            Console.WriteLine(format, 'n', "an+", "bn-", "xn=(an+bn)/2", "f(xn)");
            for (int i = 0; ; i++)
            {
	
                double x = (a + b) / 2;
                double resX = FunctionForSecondMethod(x);
                Console.WriteLine(format, i, a, b, x, resX);
                double resA = FunctionForSecondMethod(a);
                if ((resA < 0 && resX > 0) || (resA > 0 && resX < 0)) b = x;
                else a = x;
                if (b - a <= e)
                {
                    Console.WriteLine($"{a,14:0.###}{b,10:0.###}");
                    Console.WriteLine($"\nAnswer: x1 = {x:0.000}.");
                    break;
                }
            }

        }
        static void thirdMethod(double[] solutions)
		{
            Console.WriteLine("\n\n\n\n3) The equation - 0,5*x - 1 = (x+2)^2 ");
            Console.WriteLine("\ny1 = 0,5*x - 1, \ny2 = (x+2)^2,\nbuilding a chart.");
            Console.WriteLine("\nThe number of valid roots: " + solutions.Length);
            for (int i = 0; i < solutions.Length; i++)
                Console.WriteLine($"x{i + 1} = {solutions[i],4}");
        }
        static void fourthMethod(double[] solutions, double firstElement, double secondElement, 
            Dictionary<double, char> markOfFunction, string format, double exponent)
		{
            double secondGap = -1;
            Console.WriteLine("\n\n\n\n\n4) Let's build a chart wtih our function x^2*cos(2*x) = -1.");
            solutions = new double[] { -1.18, 0.00, 1.18 };
            Console.WriteLine("\nThe number of valid roots: " + solutions.Length);
            for (int i = 0; i < solutions.Length; i++)
                Console.WriteLine($"x{i + 1} = {solutions[i],6}");
            Console.WriteLine($"\nWe refine one of the roots, for example, x1 by the method of samples to hundredths." +
                $"\nTo clarify this root " +
                $"choose a gap at the ends of which the function has different marks.");
            Console.WriteLine("\nOur table is:");
            firstElement = -1.4;
            secondElement = -1;
            
            markOfFunction = new Dictionary<double, char>()
            {
                {
                    firstElement, FunctionForFourthMethod(firstElement) < 0 ? '-' : '+'
                },
                {
                    secondElement, FunctionForFourthMethod(secondElement) < 0 ? '-' : '+'
                }
            };

            foreach (var item in markOfFunction)
            {
                Console.Write($"{item,10}");
            }

            Console.WriteLine("\n\n" + format, 'n', "an+", "bn-", "xn=(an+bn)/2", "f(xn)");
            secondElement = -1.18;
            for (int i = 0;  ; i++)
            {
                double x = (firstElement + secondElement) / 2;
                double resultX = FunctionForSecondMethod(x);
                Console.WriteLine(format, i, firstElement, secondGap, x, resultX);
                double resultA = FunctionForSecondMethod(firstElement);
                if ((resultA < 0 && resultX > 0) || (resultA > 0 && resultX < 0)) secondElement = x;
                else firstElement = x;
                if (secondElement - firstElement <= exponent)
                {
                    Console.WriteLine($"{firstElement,14:0.###}{secondGap,10:0.###}");
                    Console.WriteLine($"\nAnswer is: x1 = {x:0.000}.");
                    break;
                }
            }
        }


    }
}
