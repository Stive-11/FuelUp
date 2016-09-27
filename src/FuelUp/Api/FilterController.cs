using FuelUp.Models.ApiModels;
using FuelUp.Models.DB;
using FuelUp.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FuelUp.Api
{
    [Produces("application/json")]
    public class FilterController : Controller
    {
        private readonly FuelUpContext _context;
        private readonly IGetInfo _getInfo;

        public FilterController(
            FuelUpContext context,
            IGetInfo getInfo
            )
                {
                    _context = context;
                    _getInfo = getInfo;
                }

        // POST: api/getFiltredStations
        [HttpPost]
        [Route("api/getFiltredStations")]
        public ActionResult GetMainInfo( [FromBody] Requests.Filter filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var info = _getInfo.GetFilteredInfo(filter.filters);
            var json = JsonConvert.SerializeObject(info);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok(json);

        }

    }
}