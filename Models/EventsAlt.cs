using System;
using System.Collections.Generic;

namespace Historical__Facts_3.Models;

public partial class EventsAlt
{
    public int EventId { get; set; }

    public string? Descr { get; set; }

    public int? StartYear { get; set; }

    public byte? StartMonth { get; set; }

    public byte? StartDay { get; set; }

    public int? EndYear { get; set; }

    public byte? EndMonth { get; set; }

    public byte? EndDay { get; set; }

    // Add this navigation property:
    public virtual ICollection<Fact> Facts { get; set; } = new List<Fact>();

    // If you want to include EventPersons as well:
    public virtual ICollection<EventPerson> EventPersons { get; set; } = new List<EventPerson>();



}
