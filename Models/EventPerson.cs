using System;
using System.Collections.Generic;

namespace Historical__Facts_3.Models;

public partial class EventPerson
{
    public int? EventId { get; set; }

    public int? PersonId { get; set; }

    // Add these navigation properties:
    public virtual Event? Event { get; set; }
    public virtual Person? Person { get; set; }
}
