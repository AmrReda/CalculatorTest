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
            var calculator = serviceProvider.GetService<ISimpleCalculator>();

            calculator.Add(4, 5);
            calculator.Subtract(10, 4);
            calculator.Multiply(6, 9);
            calculator.Divide(12, 3);
        }
    }
}
