using System;
using System.Collections.Generic;
using Historical__Facts_3.Controllers;

namespace Historical__Facts_3.Models;

public partial class Africa : HomeController
{
    public Africa(ILogger<HomeController> logger) : base(logger)
    {
    }

    public int HistoricalFactId { get; set; }

    public string? FactDescription { get; set; }
}
