using FuelUp.Models.DB;
using FuelUp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace FuelUp.Controllers
{
    //[EnableCors("")]
    [Produces("application/json")]
    
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
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            
            return Ok(fuelTypes);
        }

        // GET: api/FuelTypes/5

        [HttpGet]
        [Route("api/GetServiceTypes")]
        public IActionResult GetServiceTypes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceTypes = _context.ServiceTypes.Select(x=> x);

            if (serviceTypes == null)
            {
                return NotFound();
            }
            var json = JsonConvert.SerializeObject(serviceTypes);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
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
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok(json);
        }
    }
}