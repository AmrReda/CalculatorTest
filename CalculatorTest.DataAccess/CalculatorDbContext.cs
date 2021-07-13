using CalculatorTest.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculatorTest.DataAccess
{
    public class CalculatorDbContext : DbContext
    {
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options) 
            : base(options)
        {

        }
        

        public DbSet<LogDetail> Details { get; set; }
    }
}