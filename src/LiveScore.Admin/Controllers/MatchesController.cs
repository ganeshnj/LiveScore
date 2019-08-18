using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiveScore.Admin.Data;
using LiveScore.Models;
using LiveScore.Admin.Models;

namespace LiveScore.Admin.Controllers
{
    public class MatchesController : Controller
    {
        private readonly AdminContext _context;

        public MatchesController(AdminContext context)
        {
            _context = context;
        }

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Matches.Include(m => m.Team1).Include(m => m.Team2).ToListAsync());
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .Include(m => m.Team1)
                .Include(m => m.Team2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            var teams = _context.Teams.Select(t => new SelectListItem(t.Name, t.Id.ToString()));
            var viewModel = new MatchViewModel()
            {
                Teams1 = teams,
                Teams2 = teams,
            };
            return View(viewModel);
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SelectedTeam1,Teams1,SelectedTeam2,Teams2,Team1Score,Team2Score,Status")] MatchViewModel matchViewModel)
        {
            if (ModelState.IsValid)
            {
                var match = new Match()
                {
                    Team1Id = int.Parse(matchViewModel.SelectedTeam1),
                    Team2Id = int.Parse(matchViewModel.SelectedTeam2),
                    Team1Score = matchViewModel.Team1Score,
                    Team2Score = matchViewModel.Team2Score,

                };
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matchViewModel);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            var teams = _context.Teams.Select(t => new SelectListItem(t.Name, t.Id.ToString()));
            var matchViewModel = new MatchViewModel()
            {
                SelectedTeam1 = match.Team1Id.ToString(),
                SelectedTeam2 = match.Team2Id.ToString(),
                Status = match.Status,
                Team1Score = match.Team1Score,
                Team2Score = match.Team2Score,
                Teams1 = teams,
                Teams2 = teams,
            };

            return View(matchViewModel);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SelectedTeam1,Teams1,SelectedTeam2,Teams2,Team1Score,Team2Score,Status")] MatchViewModel matchViewModel)
        {
            if (id != matchViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var match = new Match()
                {
                    Id = matchViewModel.Id,
                    Team1Id = int.Parse(matchViewModel.SelectedTeam1),
                    Team2Id = int.Parse(matchViewModel.SelectedTeam2),
                    Team1Score = matchViewModel.Team1Score,
                    Team2Score = matchViewModel.Team2Score,
                    Status = matchViewModel.Status
                };
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(matchViewModel);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Matches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var match = await _context.Matches.FindAsync(id);
            _context.Matches.Remove(match);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(int id)
        {
            return _context.Matches.Any(e => e.Id == id);
        }
    }
}
