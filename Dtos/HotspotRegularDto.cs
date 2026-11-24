namespace PokestopHotSpots.Dtos;

// One line of a truck's menu, as the API says it. The dish's name instead of
// a Dish object, and no way back to the truck.
public class HotspotRegularDto
{
    public string Name { get; set; } = "";
    public string FriendshipCode { get; set; } = "";
    public bool SendsDailyGifts { get; set; } = false;
    
}