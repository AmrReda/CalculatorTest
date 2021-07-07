namespace CalculatorTest
{
    public interface IDiagnostics
    {
        void LogInformation(string message);
        void LogError(string message);
    }
}