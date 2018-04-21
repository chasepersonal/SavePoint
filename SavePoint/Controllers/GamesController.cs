using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SavePoint.Data;
using SavePoint.Models;
using SavePoint.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace SavePoint.Controllers
{
    public class GamesController : Controller
    {
        // Access database context

        private readonly SavePointDbContext _context;

        // Import UserManager to validate current user

        private readonly UserManager<ApplicationUser> _userManager;

        // Ctor to set all variables

        public GamesController(SavePointDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: Games
        [Authorize]
        public async Task<IActionResult> Index()
        {

            // Retrieve ID of current user from database

            var currentUser = _userManager.GetUserId(User);

            // Display games only for the current user

            var games = _context.Games.Where(m => m.OwnerID == currentUser);

            return View(await games.ToListAsync());
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games
                .SingleOrDefaultAsync(m => m.ID == id);
            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Consoles,Genre,ReleaseYear,Rating,Comment")] Games games)
        {


            if (ModelState.IsValid)
            {
                // Pull OwnerID and match to current logged in user
                // This will ensure that games user creates will only be displayed on their Games List page

                games.OwnerID = _userManager.GetUserId(User);
                _context.Add(games);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(games);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games.SingleOrDefaultAsync(m => m.ID == id);
            if (games == null)
            {
                return NotFound();
            }
            return View(games);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Consoles,Genre,ReleaseYear,Rating,Comment")] Games games)
        {
            if (id != games.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(games);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamesExists(games.ID))
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
            return View(games);
        }

        private bool GamesExists(int iD)
        {
            throw new NotImplementedException();
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = await _context.Games
                .SingleOrDefaultAsync(m => m.ID == id);
            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var games = await _context.Games.SingleOrDefaultAsync(m => m.ID == id);
            _context.Games.Remove(games);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult TitleAlreadyExists(string Title)
        {
            // Retrieve ID of current user from database
            // Will be used to ensure only user's games are part of the search

            var currentUser = _userManager.GetUserId(User);

            // Search user's database to see if Game Title already exists

            var currentGameTitle = (from t in _context.Games where t.OwnerID == currentUser select new { Title }).FirstOrDefault();

            // Return status value of Title
            bool exists;

            if (currentGameTitle != null)
            {
                exists = false;
            }
            else
            {
                exists = true;
            }
            return Json(data: exists);
        }
    }
}
