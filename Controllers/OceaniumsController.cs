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
    public class OceaniumsController : Controller
    {
        private readonly HistoryContext _context;

        public OceaniumsController(HistoryContext context)
        {
            _context = context;
        }

        // GET: Oceaniums
        public async Task<IActionResult> Index()
        {
            return View(await _context.Oceania.ToListAsync());
        }

        // GET: Oceaniums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oceanium = await _context.Oceania
                .FirstOrDefaultAsync(m => m.HistoricalFactId == id);
            if (oceanium == null)
            {
                return NotFound();
            }

            return View(oceanium);
        }

        // GET: Oceaniums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oceaniums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoricalFactId,FactDescription")] Oceanium oceanium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oceanium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oceanium);
        }

        // GET: Oceaniums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oceanium = await _context.Oceania.FindAsync(id);
            if (oceanium == null)
            {
                return NotFound();
            }
            return View(oceanium);
        }

        // POST: Oceaniums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoricalFactId,FactDescription")] Oceanium oceanium)
        {
            if (id != oceanium.HistoricalFactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oceanium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OceaniumExists(oceanium.HistoricalFactId))
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
            return View(oceanium);
        }

        // GET: Oceaniums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oceanium = await _context.Oceania
                .FirstOrDefaultAsync(m => m.HistoricalFactId == id);
            if (oceanium == null)
            {
                return NotFound();
            }

            return View(oceanium);
        }

        // POST: Oceaniums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oceanium = await _context.Oceania.FindAsync(id);
            if (oceanium != null)
            {
                _context.Oceania.Remove(oceanium);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OceaniumExists(int id)
        {
            return _context.Oceania.Any(e => e.HistoricalFactId == id);
        }
    }
}
