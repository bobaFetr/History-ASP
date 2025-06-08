using Historical__Facts_3.Models;
using HistoricalFacts.ViewModels;

namespace HistoricalFacts.ViewModels
{
    public class EventDetailViewModel
    {
        public Event Event { get; set; }
        public IEnumerable<Event> RelatedFacts { get; set; } = new List<Event>();
        public IEnumerable<Person> RelatedPersons { get; set; } = new List<Person>();
    }
}