

namespace Nba_Statistics.Models
{
    public class Filters
    {
        public int Limit { get; set; }

        public string Order { get; set; }

        public string Skill { get; set; }

        public Filters(int limit, string order, string skill)
        {
            Limit = limit;
            Order = order;
            Skill = skill;
        }

        public Filters()
        {
            Limit = 10;
            Order = "DESC";
            Skill = "POINTS";
        }


    }
}
