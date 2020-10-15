using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nba_Statistics.Data;
using Nba_Statistics.Models;
using Nba_Statistics.Services;

namespace Nba_Statistics.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly Nba_StatisticsContext _context;

        public PlayersController(Nba_StatisticsContext context)
        {
            _context = context;
        }

        // GET: api/Players
        [HttpGet]
        public IEnumerable<Player> GetPlayer()
        {
             var players = _context.Player;
            List<Player> result = new List<Player>();
            foreach (Player p in players.ToList()){
                Player player = p;
                player.Team = _context.Team.Find(p.TeamId);
                result.Add(player);
            }

            return result;
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _context.Player.FindAsync(id);
           

            if (player == null)
            {
                return NotFound();
            }
            player.Team = await _context.Team.FindAsync(player.TeamId);

            return Ok(player);
        }

        // PUT: api/Players/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer([FromRoute] int id, [FromBody] Player player, [FromQuery] Token token)
        {
            AuthenticationService auth = new AuthenticationService(_context);
            if (!auth.isValid(token.Key))
                return Unauthorized();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            player.Id = id;

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Players
        [HttpPost]
        public async Task<IActionResult> PostPlayer([FromBody] Player player, [FromQuery] Token token)
        {
            AuthenticationService auth = new AuthenticationService(_context);
            if (!auth.isValid(token.Key))
                return Unauthorized();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            player.Team = await _context.Team.FindAsync(player.TeamId);
            _context.Player.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
        }

        // DELETE: api/Players/5
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer([FromRoute] int id, [FromQuery] Token token)
        {
            AuthenticationService auth = new AuthenticationService(_context);
            if (!auth.isValid(token.Key))
                return Unauthorized();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var player = await _context.Player.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Player.Remove(player);
            await _context.SaveChangesAsync();

            return Ok(player);
        }

        private bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.Id == id);
        }
    }
}