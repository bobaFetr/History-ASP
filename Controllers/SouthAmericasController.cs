using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Historical__Facts_3.Data;
using Historical__Facts_3.Models;

namespace Historical__Facts_3.Controllers
{
    public class SouthAmericasController : Controller
    {
        private readonly HistoryContext _context;

        public SouthAmericasController(HistoryContext context)
        {
            _context = context;
        }

        // GET: SouthAmericas
        public async Task<IActionResult> Index()
        {
            return View(await _context.SouthAmerica.ToListAsync());
        }

        // GET: SouthAmericas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var southAmerica = await _context.SouthAmerica
                .FirstOrDefaultAsync(m => m.HistoricalFactId == id);
            if (southAmerica == null)
            {
                return NotFound();
            }

            return View(southAmerica);
        }

        // GET: SouthAmericas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SouthAmericas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoricalFactId,FactDescription")] SouthAmerica southAmerica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(southAmerica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(southAmerica);
        }

        // GET: SouthAmericas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var southAmerica = await _context.SouthAmerica.FindAsync(id);
            if (southAmerica == null)
            {
                return NotFound();
            }
            return View(southAmerica);
        }

        // POST: SouthAmericas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoricalFactId,FactDescription")] SouthAmerica southAmerica)
        {
            if (id != southAmerica.HistoricalFactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(southAmerica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SouthAmericaExists(southAmerica.HistoricalFactId))
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
            return View(southAmerica);
        }

        // GET: SouthAmericas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var southAmerica = await _context.SouthAmerica
                .FirstOrDefaultAsync(m => m.HistoricalFactId == id);
            if (southAmerica == null)
            {
                return NotFound();
            }

            return View(southAmerica);
        }

        // POST: SouthAmericas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var southAmerica = await _context.SouthAmerica.FindAsync(id);
            if (southAmerica != null)
            {
                _context.SouthAmerica.Remove(southAmerica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SouthAmericaExists(int id)
        {
            return _context.SouthAmerica.Any(e => e.HistoricalFactId == id);
        }
    }
}
