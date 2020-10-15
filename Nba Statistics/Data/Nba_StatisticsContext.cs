
using Microsoft.EntityFrameworkCore;

namespace Nba_Statistics.Data
{
    public class Nba_StatisticsContext : DbContext
    {

        public Nba_StatisticsContext (DbContextOptions<Nba_StatisticsContext> options)
            : base(options)
        {
        }
        public DbSet<Nba_Statistics.Models.Player> Player { get; set; }
        public DbSet<Nba_Statistics.Models.Team> Team { get; set; }
        public DbSet<Nba_Statistics.Models.Token> Token { get; set; }


    }
}
