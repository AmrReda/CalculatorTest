namespace CalculatorTest
{
    /// <summary>
    /// No Reporting Implementation
    /// </summary>
    public class DummyDiagnostics : IDiagnostics
    {
        public void LogInformation(string message)
        {
           //Do Nothing
        }

        public void LogError(string message)
        {
            //Do Nothing
        }
    }
}