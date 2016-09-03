using FuelUp.Models.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FuelUp.Api
{
    [Produces("application/json")]
    public class PathesController : Controller
    {
        [Route("api/Pathes/stringsPath")]
        [HttpPost]
        public IActionResult StringPathes([FromBody] Requests.PathStrings pointsPathesRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(JsonConvert.SerializeObject(pointsPathesRequest));
        }

        [Route("api/Pathes/coordinatsPath")]
        [HttpPost]
        public IActionResult StringPathes([FromBody] Requests.PathCoordinats pointsPathesRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(JsonConvert.SerializeObject(pointsPathesRequest));
        }
    }
}