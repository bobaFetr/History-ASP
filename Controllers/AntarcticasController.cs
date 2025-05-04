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
    public class AntarcticasController : Controller
    {
        private readonly HistoryContext _context;

        public AntarcticasController(HistoryContext context)
        {
            _context = context;
        }

        // GET: Antarcticas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Antarcticas.ToListAsync());
        }

        // GET: Antarcticas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antarctica = await _context.Antarcticas
                .FirstOrDefaultAsync(m => m.HistoricalFactId == id);
            if (antarctica == null)
            {
                return NotFound();
            }

            return View(antarctica);
        }

        // GET: Antarcticas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Antarcticas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoricalFactId,FactDescription")] Antarctica antarctica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(antarctica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(antarctica);
        }

        // GET: Antarcticas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antarctica = await _context.Antarcticas.FindAsync(id);
            if (antarctica == null)
            {
                return NotFound();
            }
            return View(antarctica);
        }

        // POST: Antarcticas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoricalFactId,FactDescription")] Antarctica antarctica)
        {
            if (id != antarctica.HistoricalFactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(antarctica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AntarcticaExists(antarctica.HistoricalFactId))
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
            return View(antarctica);
        }

        // GET: Antarcticas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var antarctica = await _context.Antarcticas
                .FirstOrDefaultAsync(m => m.HistoricalFactId == id);
            if (antarctica == null)
            {
                return NotFound();
            }

            return View(antarctica);
        }

        // POST: Antarcticas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var antarctica = await _context.Antarcticas.FindAsync(id);
            if (antarctica != null)
            {
                _context.Antarcticas.Remove(antarctica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AntarcticaExists(int id)
        {
            return _context.Antarcticas.Any(e => e.HistoricalFactId == id);
        }
    }
}
