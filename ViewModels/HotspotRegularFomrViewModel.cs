using Microsoft.AspNetCore.Mvc.Rendering;
using PokestopHotSpots.Models;

namespace PokestopHotSpots.ViewModels;

public class HotspotRegularFormViewModel
{
    public HotspotRegular HotspotRegular { get; set; } = new();
    public SelectList? Hotspots { get; set; }
}