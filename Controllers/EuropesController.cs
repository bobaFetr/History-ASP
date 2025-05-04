using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Historical__Facts_3.Models;

namespace Historical__Facts_3.Controllers
{
    public class EuropesController : Controller
    {
        private readonly HistoryContext _context;

        public EuropesController(HistoryContext context)
        {
            _context = context;
        }

        // GET: Europes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Europes.ToListAsync());
        }

        // GET: Europes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var europe = await _context.Europes
                .FirstOrDefaultAsync(m => m.HistoricalFactId == id);
            if (europe == null)
            {
                return NotFound();
            }

            return View(europe);
        }

        // GET: Europes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Europes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoricalFactId,FactDescription")] Europe europe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(europe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(europe);
        }

        // GET: Europes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var europe = await _context.Europes.FindAsync(id);
            if (europe == null)
            {
                return NotFound();
            }
            return View(europe);
        }

        // POST: Europes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoricalFactId,FactDescription")] Europe europe)
        {
            if (id != europe.HistoricalFactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(europe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EuropeExists(europe.HistoricalFactId))
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
            return View(europe);
        }

        // GET: Europes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var europe = await _context.Europes
                .FirstOrDefaultAsync(m => m.HistoricalFactId == id);
            if (europe == null)
            {
                return NotFound();
            }

            return View(europe);
        }

        // POST: Europes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var europe = await _context.Europes.FindAsync(id);
            if (europe != null)
            {
                _context.Europes.Remove(europe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EuropeExists(int id)
        {
            return _context.Europes.Any(e => e.HistoricalFactId == id);
        }
    }
}
