using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PokestopHotSpots.Data;
using PokestopHotSpots.Models;
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
        return View(_context.Hotspots.Include(h => h.HotspotRegulars).ToList());
    }
    public IActionResult Details(int id)
    {
        var Hotspot = _context.Hotspots.Include(h => h.HotspotRegulars).FirstOrDefault(h => h.Id == id);
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
    // editing a hotspot
    public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotspot = await _context.Hotspots.Include(h => h.HotspotRegulars).FirstOrDefaultAsync(h => h.Id == id);
            if (hotspot == null)
            {  
                return NotFound();
            }
            return View(hotspot);
        }
         [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,GymCount,PokestopDensity,hasParking, Description")] Hotspot hotspot)
        {
            if (id != hotspot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotspot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotspotExists(hotspot.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hotspot);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotspot = await _context.Hotspots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotspot == null)
            {
                return NotFound();
            }

            return View(hotspot);
        }

        // POST: HotSpotScaffold/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotspot = await _context.Hotspots.FindAsync(id);
            if (hotspot != null)
            {
                _context.Hotspots.Remove(hotspot);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    private bool HotspotExists(int id)
        {
            return _context.Hotspots.Any(e => e.Id == id);
        }
}
