using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveScore.Admin.Data;
using LiveScore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiveScore.Admin.Api
{
    [Route("api/[controller]")]
    public class MatchesController : Controller
    {
        private readonly AdminContext _context;

        public MatchesController(AdminContext context)
        {
            _context = context;
        }

        // GET: api/matches
        [HttpGet]
        public async Task<IEnumerable<Match>> Get()
        {
            return await _context.Matches.Include(m => m.Team1).Include(m => m.Team2).ToListAsync();
        }

        // GET api/matches/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Match>> Get(int id)
        {
            var match = await _context.Matches
             .Include(m => m.Team1)
             .Include(m => m.Team2)
             .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }
            return match;
        }
    }
}
