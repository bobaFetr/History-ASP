using Historical__Facts_3.Data;
using Historical__Facts_3.Models;
using HistoricalFacts.Controllers;
using HistoricalFacts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HistoricalFacts.Controllers
{
    public class EventsController : Controller
    {
        private readonly History2Context _context;

        public EventsController(History2Context context)
        {
            _context = context;
        }

        // GET: /Events
        public async Task<IActionResult> Index()
        {
            var events = await _context.Events.OrderBy(e => e.StartYear).ToListAsync();
            return View(events);
        }

        // GET: /Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var eventData = await _context.Events
                .Include(e => e.Facts) // Include Facts for the Event
                    .ThenInclude(f => f.Continent) // Include Continent for each Fact
                .Include(e => e.EventPersons)
                    .ThenInclude(ep => ep.Person) // Include Person for each join entry
                .FirstOrDefaultAsync(e => e.EventID == id);

            if (eventData == null) return NotFound();

            var viewModel = new EventDetailViewModel
            {
                Event = eventData,
                RelatedFacts = eventData.Facts.Select(f => new FactInfoViewModel
                {
                    FactID = f.FactID,
                    Description = f.Description,
                    FactYear = f.FactYear,
                    ContinentName = f.Continent?.ContName ?? "N/A"
                }).OrderBy(f=>f.FactYear),
                RelatedPersons = eventData.EventPersons.Select(ep => ep.Person!)
            };

            return View(viewModel);
        }
    }
}