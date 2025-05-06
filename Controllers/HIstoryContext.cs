using Microsoft.EntityFrameworkCore;

namespace Historical__Facts_3
{
    public class HistoryContext : DbContext
    {
        public HistoryContext(DbContextOptions<HistoryContext> options) : base(options)
        {
        }

        // Define DbSet properties for your entities here
        // Example:
        public DbSet<HistoricalFact> HistoricalFacts { get; set; }
    }
}