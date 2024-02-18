using LocationAvailabilityAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocationAvailabilityAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private static List<Location> locations = new List<Location>
    {
        new Location { Name = "Location 1", AvailabilityStart = TimeSpan.FromHours(10), AvailabilityEnd = TimeSpan.FromHours(13) },
        new Location { Name = "Location 2", AvailabilityStart = TimeSpan.FromHours(9), AvailabilityEnd = TimeSpan.FromHours(14) }
        // Add more locations here
    };

        [HttpGet]
        public IEnumerable<Location> GetLocationsWithAvailability()
        {
            var currentTime = DateTime.Now.TimeOfDay;
            return locations.FindAll(loc => currentTime >= loc.AvailabilityStart && currentTime <= loc.AvailabilityEnd);
        }

        [HttpPost]
        public IActionResult AddLocation(Location location)
        {
            locations.Add(location);
            return Ok();
        }
    }
