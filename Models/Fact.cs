using System;
using System.Collections.Generic;

namespace Historical__Facts_3.Models;

public partial class Fact
{
    public int FactId { get; set; }

    public string? Description { get; set; }

    public int? EventId { get; set; }

    public int? ContinentId { get; set; }

    public int? FactYear { get; set; }

    public byte? FactMonth { get; set; }

    public byte? FactDay { get; set; }
}
