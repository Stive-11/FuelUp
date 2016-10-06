using FuelUp.Models.ApiModels;
using FuelUp.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FuelUp.Api
{
    [Produces("application/json")]
    public class FilterController : Controller
    {
        private readonly IGetInfo _getInfo;

        public FilterController(
            IGetInfo getInfo
            )
        {
            _getInfo = getInfo;
        }

        // POST: api/getFiltredStations
        [HttpPost]
        [Route("api/getFiltredStations")]
        public ActionResult GetFiltredStations([FromBody] Requests.Filter filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var info = _getInfo.GetFilteredInfo(filter.filters);
            var json = JsonConvert.SerializeObject(info);
            return Ok(json);
        }

        // POST: api/getAllStationsWithFilter
        [HttpPost]
        [Route("api/getAllStationsWithFilter")]
        public ActionResult GetAllStationsWithFilter([FromBody] Requests.Filter filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var info = _getInfo.GetAllStationsWithFilterInfo(filter.filters);
            var json = JsonConvert.SerializeObject(info);
            return Ok(json);
        }
    }
}