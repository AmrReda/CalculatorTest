using System;

namespace CalculatorTest.DataAccess.Models
{
    public class LogDetail
    {
        public Verbose Verbose { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}