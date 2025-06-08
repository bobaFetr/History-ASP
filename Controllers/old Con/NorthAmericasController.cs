using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Historical__Facts_3.Models;
using Historical__Facts_3.Data;

namespace Historical__Facts_3.Controllers
{
    public class NorthAmericasController : Controller
    {
        private readonly HistoryContext _context;

        public NorthAmericasController(HistoryContext context)
        {
            _context = context;
        }

        // GET: NorthAmericas
        public async Task<IActionResult> Index()
        {
            return View(await _context.NorthAmerica.ToListAsync());
        }

        // GET: NorthAmericas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var northAmerica = await _context.NorthAmerica
                .FirstOrDefaultAsync(m => m.HistoricalFactId == id);
            if (northAmerica == null)
            {
                return NotFound();
            }

            return View(northAmerica);
        }

        // GET: NorthAmericas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NorthAmericas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoricalFactId,FactDescription")] NorthAmerica northAmerica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(northAmerica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(northAmerica);
        }

        // GET: NorthAmericas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var northAmerica = await _context.NorthAmerica.FindAsync(id);
            if (northAmerica == null)
            {
                return NotFound();
            }
            return View(northAmerica);
        }

        // POST: NorthAmericas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoricalFactId,FactDescription")] NorthAmerica northAmerica)
        {
            if (id != northAmerica.HistoricalFactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(northAmerica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NorthAmericaExists(northAmerica.HistoricalFactId))
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
            return View(northAmerica);
        }

        // GET: NorthAmericas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var northAmerica = await _context.NorthAmerica
                .FirstOrDefaultAsync(m => m.HistoricalFactId == id);
            if (northAmerica == null)
            {
                return NotFound();
            }

            return View(northAmerica);
        }

        // POST: NorthAmericas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var northAmerica = await _context.NorthAmerica.FindAsync(id);
            if (northAmerica != null)
            {
                _context.NorthAmerica.Remove(northAmerica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NorthAmericaExists(int id)
        {
            return _context.NorthAmerica.Any(e => e.HistoricalFactId == id);
        }
    }
}
