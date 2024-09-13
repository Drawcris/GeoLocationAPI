using GeoLocationAPI.Data;
using GeoLocationAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeoLocationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly DataContext _context;

        public AdressesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdresses()
        {
            var adresses = await _context.Locations.ToListAsync();

            return Ok(adresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdress(int id)
        {
            var adress = await _context.Locations.FindAsync(id);
            if(adress is null)
                return NotFound();

            return Ok(adress);
        }

        [HttpPost]
        public async Task<IActionResult> AddAdress(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return Ok(await _context.Locations.ToListAsync());
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            var adress = await _context.Locations.FindAsync(id);
            if(adress is null)
                return NotFound();

            _context.Locations.Remove(adress);
            await _context.SaveChangesAsync();
            return Ok(await _context.Locations.ToListAsync());
        }


    }
}
