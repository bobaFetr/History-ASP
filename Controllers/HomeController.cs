using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Historical__Facts_3.Models;

namespace Historical__Facts_3.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public WW2Armies WW2ArmiesClass { get; private set; }

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // filepath: c:\Users\Lenovo\Desktop\ASP .NET\Historical Facts Official\Historical facts 3\Historical  Facts 3\Controllers\HomeController.cs
    // public IActionResult Africa1()
    // {
    //     var africa = new Africa(_logger)
    //     {
    //         HistoricalFactId = 1,
    //         FactDescription = "Sample historical fact about Africa."
    //     };
    //     return View(africa);
    // }
    public async Task<IActionResult> Africa1()
    {
        var africa = await Task.Run(() => new Africa(_logger)
        {
            HistoricalFactId = 1,
            FactDescription = "Sample historical fact about Africa."
        });

        return View(africa);
    }

    public async Task<IActionResult> WW2Armies()
    {
        var ww2ArmiesClass = new WW2Armies(_logger)
        {
            Country = "Soviet Union",
            ArmySize = 34000000
        };
        var ww2Armies = await Task.Run(() => WW2ArmiesClass?.ToString());
        return View(ww2Armies);
    }

    // filepath: c:\Users\Lenovo\Desktop\ASP .NET\Historical Facts Official\Historical facts 3\Historical  Facts 3\Controllers\HomeController.cs


    // public async Task<IActionResult> WW2Armies()
    // {
    //     var ww2ArmiesClass = new WW2Armies(_logger)
    //     {
    //         Country = "Soviet Union",
    //         ArmySize = 34000000
    //     };
    //     var ww2Armies = await Task.Run(() => WW2ArmiesClass?.GetArmyData());
    //     return View(ww2Armies);
    // }
}
