using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Historical__Facts_3.Models;

public partial class SouthAmerica
{
    [Key]
    public int HistoricalFactId { get; set; }

    public string? FactDescription { get; set; }
}
