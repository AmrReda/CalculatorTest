using System;
using CalculatorTest.DataAccess.Models;

namespace CalculatorTest.DataAccess
{
    public class DbDiagnostics : IDiagnostics
    {
        private readonly CalculatorDbContext _context;

        public DbDiagnostics(CalculatorDbContext context)
        {
            _context = context;
        }

        public void LogInformation(string message)
        {
            SaveLogDetail(message, Verbose.Information);
        }

        public void LogError(string message)
        {
            SaveLogDetail(message, Verbose.Error);
        }

        private void SaveLogDetail(string message, Verbose verbose)
        {
            var logDetail = new LogDetail()
            {
                Message = message,
                Verbose = verbose,
                CreatedDate = DateTime.UtcNow
            };

            _context.Details.Add(logDetail);
            _context.SaveChanges();
        }
    }
}
