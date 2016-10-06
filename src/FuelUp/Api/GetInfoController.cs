using System.Linq;
using System.Threading.Tasks;
using FuelUp.Models.DB;
using FuelUp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FuelUp.Api
{
    [Produces("application/json")]
    public class GetInfoController : Controller
    {
        private readonly FuelUpContext _context;
        private readonly IGetInfo _getInfo;

        public GetInfoController(
            FuelUpContext context,
            IGetInfo getInfo
            )
        {
            _context = context;
            _getInfo = getInfo;
        }

        // GET: api/FuelTypes/5

        [HttpGet("{id}")]
        [Route("api/FuelTypes")]
        public async Task<IActionResult> GetFuelTypes(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fuelTypes = await _context.FuelTypes.SingleOrDefaultAsync(m => m.ID == id);

            if (fuelTypes == null)
            {
                return NotFound();
            }
            return Ok(fuelTypes);
        }

        // GET: api/GetServiceTypes

        [HttpGet]
        [Route("api/GetServiceTypes")]
        public IActionResult GetServiceTypes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceTypes = _context.ServiceTypes.Select(x => x);

            if (serviceTypes == null)
            {
                return NotFound();
            }
            var json = JsonConvert.SerializeObject(serviceTypes);
            return Ok(json);
        }

        // GET: api/GetMainInfo
        [HttpGet]
        [Route("api/GetMainInfo")]
        public ActionResult GetMainInfo()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var info = _getInfo.GetMainInfo();
            var json = JsonConvert.SerializeObject(info);
            return Ok(json);
        }
    }
}