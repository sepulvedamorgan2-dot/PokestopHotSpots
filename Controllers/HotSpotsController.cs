using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PokestopHotSpots.Models;

namespace PokestopHotSpots.Controllers;

public class HotSpotsController : Controller
{
    public IActionResult Index()
    {
        return View(HotSpotData.All);
    }
    public IActionResult Details(int id)
    {
        var Hotspot = HotSpotData.All.FirstOrDefault(h => h.Id == id);
        if (Hotspot == null)
        {
            return NotFound();
        }
        return View(Hotspot);
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
