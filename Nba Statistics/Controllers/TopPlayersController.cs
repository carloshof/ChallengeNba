
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nba_Statistics.Data;
using Nba_Statistics.Models;

namespace Nba_Statistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopPlayersController : ControllerBase
    {
        private readonly Nba_StatisticsContext _context;

        public TopPlayersController(Nba_StatisticsContext context)
        {
            _context = context;
        }

        // GET: api/TopPlayers
        [HttpGet]
        public async Task<IActionResult> GetTopPlayer([FromQuery] Filters filters)
        {
            var Players = await _context.Player.ToListAsync();
            List<Player> PlayersResult;
            switch ((filters.Skill.ToUpper()))
            {
                case "POINTS":
                    PlayersResult = (filters.Order.ToUpper().Equals("ASC") ? Players.OrderBy(x => x.Points).ToList() : Players.OrderByDescending(x => x.Points).ToList());
                    break;
                case "REBOUNDS":
                    PlayersResult = (filters.Order.ToUpper().Equals("ASC") ? Players.OrderBy(x => x.Rebounds).ToList() : Players.OrderByDescending(x => x.Rebounds).ToList());
                    break;
                case "ASSISTS":
                    PlayersResult = (filters.Order.ToUpper().Equals("ASC") ? Players.OrderBy(x => x.Assists).ToList() : Players.OrderByDescending(x => x.Assists).ToList());
                    break;
                default:
                    PlayersResult = Players;
                    break;
            }

      

            return Ok(PlayersResult.Take(filters.Limit));

        }
    }
}