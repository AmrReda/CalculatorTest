
using System.Threading.Tasks;
using CalculatorTest.Console.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorTest.Console
{
    using System;
    
    class Program
    {  
        static void Main(string[] args)
        {
            //setup our DI
             var serviceProvider = new ServiceCollection()
                .AddSingleton<ISimpleCalculator, SimpleCalculator>()
                .AddSingleton<IDiagnostics, Diagnostics>()
                .BuildServiceProvider();



            Console.WriteLine("Simple Calculator");
            string answer = String.Empty;
            while (answer != "L" && answer != "W")
            {
                Console.WriteLine("Would you like to use the local version or the Web API version?");
                Console.WriteLine("L for Local, W for Web API:");
                answer = Console.ReadLine();
            }


            var calculator = (ISimpleCalculator)serviceProvider.GetService(typeof(ISimpleCalculator));

            if (answer == "L")
            {
                LocalVersion(calculator);
            }
            else
            {
                WebApiVersion(calculator);
            }
        }

        private static void WebApiVersion(ISimpleCalculator calculator)
        {
            Console.WriteLine("Using WebApi version");
            var calculatorApi = new CalculatorWebVersion(ApiHelper.InitializeClient());

            string usedOperator = "";
            string int1String;
            int int1;
            do
            {
                Console.WriteLine("Choose the first number");
                int1String = Console.ReadLine();
            } while (!int.TryParse(int1String, out int1));
            Console.WriteLine($"First number Chosen: {int1}");

            while (usedOperator != "*" && usedOperator != "/" && usedOperator != "-" && usedOperator != "+")
            {
                Console.WriteLine("Please the operator from the list provided: *,/,+,-");
                usedOperator = Console.ReadLine();
            }
            Console.WriteLine($"Operator Chosen: {usedOperator}");

            int int2;
            Console.WriteLine("Choose the second number:");
            while (!int.TryParse(Console.ReadLine(), out int2))
            {
                Console.WriteLine("Choose the second number");
            }
            Console.WriteLine($"Second number Chosen: {int2}");


            Task<int> ans;
            if (usedOperator == "+") ans = calculatorApi.Add(int1, int2);
            else if (usedOperator == "-") ans = calculatorApi.Subtract(int1, int2);
            else if (usedOperator == "*") ans = calculatorApi.Multiply(int1, int2);
            else ans = calculatorApi.Divide(int1, int2);

            Console.WriteLine($"Ans is: {ans.Result}");
            Console.ReadLine();

        }

        public static void LocalVersion(ISimpleCalculator calculator)
            {
                Console.WriteLine("Using local version");
                string usedOperator = "";
                string int1String;
                int int1;
                do
                {
                    Console.WriteLine("Choose the first number");
                    int1String = Console.ReadLine();
                } while (!int.TryParse(int1String, out int1));
                Console.WriteLine($"First number Chosen: {int1}");

                while (usedOperator != "*" && usedOperator != "/" && usedOperator != "-" && usedOperator != "+")
                {
                    Console.WriteLine("Please the operator from the list provided: *,/,+,-");
                    usedOperator = Console.ReadLine();
                }
                Console.WriteLine($"Operator Chosen: {usedOperator}");

                int int2;
                Console.WriteLine("Choose the second number:");
                while (!int.TryParse(Console.ReadLine(), out int2))
                {
                    Console.WriteLine("Choose the second number");
                }
                Console.WriteLine($"Second number Chosen: {int2}");


                switch (usedOperator)
                {
                    case "+":
                        calculator.Add(int1, int2);
                        break;
                    case "-":
                        calculator.Subtract(int1, int2);
                        break;
                    case "*":
                        calculator.Multiply(int1, int2);
                        break;
                    default:
                        calculator.Divide(int1, int2);
                        break;
                }
                Console.ReadLine();

            }
        }
}
