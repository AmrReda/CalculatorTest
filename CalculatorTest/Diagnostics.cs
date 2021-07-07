using System;

namespace CalculatorTest
{
    /// <summary>
    /// Console Logger
    /// </summary>
    public class Diagnostics : IDiagnostics
    {
        public void LogInformation(string message)
        {
            Console.WriteLine($"{DateTime.UtcNow} [Information]: {message}");
        }

        public void LogError(string message)
        {
            Console.WriteLine($"{DateTime.UtcNow} [Error]: {message}");
        }
    }
}