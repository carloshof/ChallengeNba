

namespace Nba_Statistics.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Championships { get; set; }

        public Team()
        {

        }

        public Team(int id, string name, int championships)
        {
            Id = id;
            Name = name;
            Championships = championships;
        }
    }
}
