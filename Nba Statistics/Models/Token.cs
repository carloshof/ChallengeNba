

namespace Nba_Statistics.Models
{
    public class Token
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public Token()
        {

        }

        public Token(int id, string key)
        {
            Id = id;
            Key = key;
        }
    }
}
