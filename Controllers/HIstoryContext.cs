using Microsoft.EntityFrameworkCore;

using Historical__Facts_3.Models;

namespace Historical__Facts_3
{
    public class HistoryContext : DbContext
    {
        public HistoryContext(DbContextOptions<HistoryContext> options) : base(options)
        {
        }

        // Define DbSet properties for your entities here
        // Example:

        public DbSet<Asium> Asia { get; set; }
        public DbSet<Africa> Africas { get; set; }
        public DbSet<Oceanium> Oceania { get; set; }
        public DbSet<SouthAmerica> SouthAmericas { get; set; }
            public DbSet<NorthAmerica> NorthAmericas { get; set; }
            public DbSet<Europe> Europes { get; set; }
            public DbSet<Antarctica> Antarcticas { get; set; }
        public DbSet<DbContext> HistoricalFacts { get; set; }
    }
}