
using Microsoft.AspNetCore.Mvc;
using Nba_Statistics.Models;

namespace Nba_Statistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoIsTheKingController : ControllerBase
    {
        // GET: api/WhoIsTheKing
        [HttpGet]
        public ActionResult TheKing()
        {
            Team Lakers = new Team(24, "Los Angeles Lakers", 10);
            Player James = new Player(23,"Lebron James", 34241,10542,9346);
            James.Team = Lakers;
            return Ok(James);
        }
    }
}
