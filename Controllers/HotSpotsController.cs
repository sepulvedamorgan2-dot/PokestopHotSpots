
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PokestopHotSpots.Models;
using PokestopHotSpots.Data;
namespace PokestopHotSpots.Controllers;

public class HotSpotsController : Controller
{
    private readonly PokestopHotspotContext _context;

    public HotSpotsController(PokestopHotspotContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View(_context.Hotspots.ToList());
    }
    public IActionResult Details(int id)
    {
        var Hotspot = _context.Hotspots.FirstOrDefault(h => h.Id == id);
        if (Hotspot == null)
        {
            return NotFound();
        }
        return View(Hotspot);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken] //Always use  this, checks for a fake request(security measure)
    public IActionResult Create(Hotspot hotspot)
    {
        // Checks if submitted model follows the rules defined in the model class
        if (!ModelState.IsValid)
        {
            // if not, return the add a hotspot view with the same data so the user doesnt have to repeat it all
            return View(hotspot);
        
        }
        _context.Hotspots.Add(hotspot);
        _context.SaveChanges();


        return RedirectToAction(nameof(Index));
    
    
       
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
