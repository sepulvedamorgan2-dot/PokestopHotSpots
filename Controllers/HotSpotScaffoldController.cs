using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PokestopHotSpots.Data;
using PokestopHotSpots.Models;

namespace PokestopHotSpots.Controllers
{
    public class HotSpotScaffoldController : Controller
    {
        private readonly PokestopHotspotContext _context;

        public HotSpotScaffoldController(PokestopHotspotContext context)
        {
            _context = context;
        }

        // GET: HotSpotScaffold
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hotspots.ToListAsync());
        }

        // GET: HotSpotScaffold/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: HotSpotScaffold/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotSpotScaffold/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,GymCount,PokestopDensity,hasParking")] Hotspot hotspot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotspot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotspot);
        }

        // GET: HotSpotScaffold/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotspot = await _context.Hotspots.FindAsync(id);
            if (hotspot == null)
            {
                return NotFound();
            }
            return View(hotspot);
        }

        // POST: HotSpotScaffold/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,GymCount,PokestopDensity,hasParking")] Hotspot hotspot)
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

        // GET: HotSpotScaffold/Delete/5
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

        private bool HotspotExists(int id)
        {
            return _context.Hotspots.Any(e => e.Id == id);
        }
    }
}
