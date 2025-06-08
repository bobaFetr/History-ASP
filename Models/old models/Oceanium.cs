using System;
using System.Collections.Generic;

namespace Historical__Facts_3.Models;
using System.ComponentModel.DataAnnotations;
public partial class Oceanium
{
    [Key]
    public int HistoricalFactId { get; set; }

    public string? FactDescription { get; set; }
}
