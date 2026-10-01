using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PokestopHotSpots.Models;
using PokestopHotSpots.Data;
namespace PokestopHotSpots.Controllers;

public class HomeController : Controller
{

    private readonly PokestopHotspotContext _context;

    public HomeController(PokestopHotspotContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        
        return View(_context.Hotspots.ToList());
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



}
