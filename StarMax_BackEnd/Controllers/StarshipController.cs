using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarMaxApp.Data;
using StarMaxApp.Models;

namespace StarMaxApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarshipsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StarshipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Starship>>> GetStarships()
        {
            var starships = await _context.Starships.ToListAsync();
            return Ok(starships);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Starship>> GetStarship(int id)
        {
            var starship = await _context.Starships.FindAsync(id);

            if (starship == null)
            {
                return NotFound();
            }

            return starship;
        }
    }
}
