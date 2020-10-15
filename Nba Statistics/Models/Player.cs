

namespace Nba_Statistics.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int Rebounds { get; set; }
        public int Assists { get; set; }
        public Team Team { get; set; }
        public int TeamId { get; set; }

        public Player()
        {

        }

        public Player(int id, string name, int points, int rebounds, int assists)
        {
            Id = id;
            Name = name;
            Points = points;
            Rebounds = rebounds;
            Assists = assists;
        }
    }
}
