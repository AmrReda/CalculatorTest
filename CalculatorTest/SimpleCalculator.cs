using System;

namespace CalculatorTest
{
    public class SimpleCalculator : ISimpleCalculator
    {
        private readonly IDiagnostics _diagnostics;

        public SimpleCalculator(IDiagnostics diagnostics)
        {
            _diagnostics = diagnostics;
        }

        public int Add(int start, int amount)
        {

            var result = start + amount;

            _diagnostics.LogInformation($"{start} + {amount} = {result}");
            
            return result;
        }
        public int Subtract(int start, int amount)
        {
            var result = start - amount;

            _diagnostics.LogInformation($"{start} - {amount} = {result}");

            return result;
        }
        public int Multiply(int start, int by)
        {
            int result = start * by;

            _diagnostics.LogInformation($"{start} * {by} = {result}");

            return result;
        }

        public int Divide(int start, int by)
        {
            int result;

            try
            {
                result = start / by;
            }
            catch (DivideByZeroException ex)
            {
                _diagnostics.LogError(ex.Message);
                throw;
            }

            _diagnostics.LogInformation($"{start} / {by} = {result}");
            return result;

        }

       
    }
}