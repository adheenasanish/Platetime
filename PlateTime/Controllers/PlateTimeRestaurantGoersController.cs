using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlateTimeApp.Models;

namespace PlateTimeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlateTimeRestaurantGoersController : ControllerBase
    {
        private readonly PlateTimeContext _context;

        public PlateTimeRestaurantGoersController(PlateTimeContext context)
        {
            _context = context;
        }

        // GET: api/PlateTimeRestaurantGoers
        [HttpGet]
        public IEnumerable<PlateTimeRestaurantGoer> GetPlateTimeRestaurantGoer()
        {
            return _context.PlateTimeRestaurantGoer;
        }

        // GET: api/PlateTimeRestaurantGoers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlateTimeRestaurantGoer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plateTimeRestaurantGoer = await _context.PlateTimeRestaurantGoer.FindAsync(id);

            if (plateTimeRestaurantGoer == null)
            {
                return NotFound();
            }

            return Ok(plateTimeRestaurantGoer);
        }

        // PUT: api/PlateTimeRestaurantGoers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlateTimeRestaurantGoer([FromRoute] int id, [FromBody] PlateTimeRestaurantGoer plateTimeRestaurantGoer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plateTimeRestaurantGoer.Id)
            {
                return BadRequest();
            }

            _context.Entry(plateTimeRestaurantGoer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlateTimeRestaurantGoerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlateTimeRestaurantGoers
        [HttpPost]
        public async Task<IActionResult> PostPlateTimeRestaurantGoer([FromBody] PlateTimeRestaurantGoer plateTimeRestaurantGoer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PlateTimeRestaurantGoer.Add(plateTimeRestaurantGoer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlateTimeRestaurantGoer", new { id = plateTimeRestaurantGoer.Id }, plateTimeRestaurantGoer);
        }

        // DELETE: api/PlateTimeRestaurantGoers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlateTimeRestaurantGoer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plateTimeRestaurantGoer = await _context.PlateTimeRestaurantGoer.FindAsync(id);
            if (plateTimeRestaurantGoer == null)
            {
                return NotFound();
            }

            _context.PlateTimeRestaurantGoer.Remove(plateTimeRestaurantGoer);
            await _context.SaveChangesAsync();

            return Ok(plateTimeRestaurantGoer);
        }

        private bool PlateTimeRestaurantGoerExists(int id)
        {
            return _context.PlateTimeRestaurantGoer.Any(e => e.Id == id);
        }
    }
}