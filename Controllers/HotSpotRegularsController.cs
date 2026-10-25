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
using PokestopHotSpots.ViewModels;
namespace PokestopHotSpots.Controllers;

public class HotSpotRegularsController : Controller
{
    private readonly PokestopHotspotContext _context;

    public HotSpotRegularsController(PokestopHotspotContext context)
    {
        _context = context;
    }

    public IActionResult Create(int id) 
{
    
    
    HotspotRegularFormViewModel form = new HotspotRegularFormViewModel
    {
        HotspotRegular = new HotspotRegular { HotspotId = id },
        Hotspots = HotspotChoices(id)
    };
    return View(form);
}


    [HttpPost]
    [ValidateAntiForgeryToken] //Always use  this, checks for a fake request(security measure)
    public IActionResult Create(HotspotRegular hotspotRegular)
    {
        // Checks if submitted model follows the rules defined in the model class
        if (!ModelState.IsValid)
        {
            // if not, return the add a hotspot view with the same data so the user doesnt have to repeat it all
            var form = new HotspotRegularFormViewModel
            {
                HotspotRegular = hotspotRegular,
                Hotspots = HotspotChoices(hotspotRegular.HotspotId)
            };
            return View(form);
        
        }
        _context.HotspotRegulars.Add(hotspotRegular);
        _context.SaveChanges();


        return RedirectToAction("Details", "HotSpots", new { id = hotspotRegular.HotspotId });
    
    
       
    }



    // // editing a hotspot
    // public async Task<IActionResult> Edit(int? id)
    //     {
    //         if (id == null)
    //         {
    //             return NotFound();
    //         }

    //         var hotspot = await _context.Hotspots.Include(h => h.HotspotRegulars).FirstOrDefaultAsync(h => h.Id == id);
    //         if (hotspot == null)
    //         {  
    //             return NotFound();
    //         }
    //         return View(hotspot);
    //     }
    //      [HttpPost]
    //     [ValidateAntiForgeryToken]
    //     public async Task<IActionResult> Edit(int id, [Bind("Id,Name,GymCount,PokestopDensity,hasParking, Description")] Hotspot hotspot)
    //     {
    //         if (id != hotspot.Id)
    //         {
    //             return NotFound();
    //         }

    //         if (ModelState.IsValid)
    //         {
    //             try
    //             {
    //                 _context.Update(hotspot);
    //                 await _context.SaveChangesAsync();
    //             }
    //             catch (DbUpdateConcurrencyException)
    //             {
    //                 if (!HotspotExists(hotspot.Id))
    //                 {
    //                     return NotFound();
    //                 }
    //                 else
    //                 {
    //                     throw;
    //                 }
    //             }
    //             return RedirectToAction(nameof(Index));
    //         }
    //         return View(hotspot);
    //     }

    //     public async Task<IActionResult> Delete(int? id)
    //     {
    //         if (id == null)
    //         {
    //             return NotFound();
    //         }

    //         var hotspot = await _context.Hotspots
    //             .FirstOrDefaultAsync(m => m.Id == id);
    //         if (hotspot == null)
    //         {
    //             return NotFound();
    //         }

    //         return View(hotspot);
    //     }

    //     // POST: HotSpotScaffold/Delete/5
    //     [HttpPost, ActionName("Delete")]
    //     [ValidateAntiForgeryToken]
    //     public async Task<IActionResult> DeleteConfirmed(int id)
    //     {
    //         var hotspot = await _context.Hotspots.FindAsync(id);
    //         if (hotspot != null) 
    //         {
    //             _context.Hotspots.Remove(hotspot);
    //         }

    //         await _context.SaveChangesAsync();
    //         return RedirectToAction(nameof(Index));
    //     }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    private bool HotspotExists(int id)
        {
            return _context.Hotspots.Any(e => e.Id == id);
        }
        
    private SelectList HotspotChoices(int? selected) =>
        new SelectList(_context.Hotspots.OrderBy(c => c.Name).ToList(), "Id", "Name", selected);
    
}

