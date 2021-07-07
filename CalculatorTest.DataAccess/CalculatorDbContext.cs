using CalculatorTest.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculatorTest.DataAccess
{
    public class CalculatorDbContext : DbContext
    {
        public DbSet<LogDetail> Details { get; set; }
    }
}