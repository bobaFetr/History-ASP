using Historical__Facts_3.Models;
using HistoricalFacts.ViewModels;
using HistoricalFacts.Areas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HistoricalFacts.Areas.Admin.Controllers
{
    [Area("Admin")] // IMPORTANT
    public class EventsController : Controller
    {
        private readonly History2Context _context;

        public EventsController(History2Context context)
        {
            _context = context;
        }

        // GET: Admin/Events
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        // GET: Admin/Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,Descr,StartYear,StartMonth,StartDay,EndYear,EndMonth,EndDay")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // Other Actions (Edit GET/POST, Delete GET/POST, Details) would go here...
        // They follow the standard scaffolding template.
    }
}