using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FuelUp.Models.DB;
using FuelUp.Models.ApiModels;
using FuelUp.Services;

namespace FuelUp.Controllers
{
    [Produces("application/json")]
    [Route("api/GetMainInfo")]
    public class FuelTypesController : Controller
    {
        private readonly FuelUpContext _context;
        private readonly IGetInfo _getInfo;

        public FuelTypesController(
            FuelUpContext context,
            IGetInfo getInfo
            )
        {
            _context = context;
            _getInfo = getInfo;
        }

        // GET: api/GetMainInfo
        [HttpGet]
        public ActionResult GetMainInfo()
        {
            var info = _getInfo.GetMainInfo();
            var json = Json(info);
            return json;
        }

        // GET: api/FuelTypes/5
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetFuelTypes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FuelTypes fuelTypes = await _context.FuelTypes.SingleOrDefaultAsync(m => m.ID == id);

            if (fuelTypes == null)
            {
                return NotFound();
            }

            return Ok(fuelTypes);
        }

        // PUT: api/FuelTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuelTypes([FromRoute] int id, [FromBody] FuelTypes fuelTypes)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (id != fuelTypes.ID)
            {
                return BadRequest();
            }

            _context.Entry(fuelTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuelTypesExists(id))
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

        // POST: api/FuelTypes
        [HttpPost]
        public async Task<IActionResult> PostFuelTypes([FromBody] FuelTypes fuelTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FuelTypes.Add(fuelTypes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FuelTypesExists(fuelTypes.ID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFuelTypes", new { id = fuelTypes.ID }, fuelTypes);
        }

        // DELETE: api/FuelTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuelTypes([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FuelTypes fuelTypes = await _context.FuelTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (fuelTypes == null)
            {
                return NotFound();
            }

            _context.FuelTypes.Remove(fuelTypes);
            await _context.SaveChangesAsync();

            return Ok(fuelTypes);
        }

        private bool FuelTypesExists(int id)
        {
            return _context.FuelTypes.Any(e => e.ID == id);
        }
    }
}