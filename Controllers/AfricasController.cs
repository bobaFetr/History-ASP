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
    public class AfricasController : Controller
    {
        private readonly HistoryContext _context;

        public AfricasController(HistoryContext context)
        {
            _context = context;
        }

        // GET: Africas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Africas.ToListAsync());
        }

        // GET: Africas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var africa = await _context.Africas
                .FirstOrDefaultAsync(m => m.HistoricalFactId == id);
            if (africa == null)
            {
                return NotFound();
            }

            return View(africa);
        }

        // GET: Africas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Africas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoricalFactId,FactDescription")] Africa africa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(africa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(africa);
        }

        // GET: Africas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var africa = await _context.Africas.FindAsync(id);
            if (africa == null)
            {
                return NotFound();
            }
            return View(africa);
        }

        // POST: Africas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoricalFactId,FactDescription")] Africa africa)
        {
            if (id != africa.HistoricalFactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(africa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AfricaExists(africa.HistoricalFactId))
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
            return View(africa);
        }

        // GET: Africas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var africa = await _context.Africas
                .FirstOrDefaultAsync(m => m.HistoricalFactId == id);
            if (africa == null)
            {
                return NotFound();
            }

            return View(africa);
        }

        // POST: Africas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var africa = await _context.Africas.FindAsync(id);
            if (africa != null)
            {
                _context.Africas.Remove(africa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AfricaExists(int id)
        {
            return _context.Africas.Any(e => e.HistoricalFactId == id);
        }
    }
}

