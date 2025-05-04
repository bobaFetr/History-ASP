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
    public class AsiaController : Controller
    {
        private readonly HistoryContext _context;

        public AsiaController(HistoryContext context)
        {
            _context = context;
        }

        // GET: Asia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Asia.ToListAsync());
        }

        // GET: Asia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asium = await _context.Asia
                .FirstOrDefaultAsync(m => m.HistoricalFactId == id);
            if (asium == null)
            {
                return NotFound();
            }

            return View(asium);
        }

        // GET: Asia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Asia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoricalFactId,FactDescription")] Asium asium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asium);
        }

        // GET: Asia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asium = await _context.Asia.FindAsync(id);
            if (asium == null)
            {
                return NotFound();
            }
            return View(asium);
        }

        // POST: Asia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoricalFactId,FactDescription")] Asium asium)
        {
            if (id != asium.HistoricalFactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsiumExists(asium.HistoricalFactId))
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
            return View(asium);
        }

        // GET: Asia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asium = await _context.Asia
                .FirstOrDefaultAsync(m => m.HistoricalFactId == id);
            if (asium == null)
            {
                return NotFound();
            }

            return View(asium);
        }

        // POST: Asia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asium = await _context.Asia.FindAsync(id);
            if (asium != null)
            {
                _context.Asia.Remove(asium);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsiumExists(int id)
        {
            return _context.Asia.Any(e => e.HistoricalFactId == id);
        }
    }
}
