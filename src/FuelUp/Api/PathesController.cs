using FuelUp.Models.ApiModels;
using FuelUp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FuelUp.Api
{
    [Produces("application/json")]
    public class PathesController : Controller
    {
        private readonly IGoogleMap _googleMap;

        public PathesController(
            IGoogleMap googleMap
            )
        {
            _googleMap = googleMap;
        }

        [Route("api/Pathes/stringsPath")]
        [HttpPost]
        public IActionResult StringPathes([FromBody] Requests.PathStrings pointsPathesRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var returnString = _googleMap.GetStringDirectionWithoutPoints(pointsPathesRequest);
            return Ok(returnString);
        }

        [Route("api/Pathes/coordinatsPath")]
        [HttpPost]
        public IActionResult StringPathes([FromBody] Requests.PathCoordinats pointsPathesRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var returnString = _googleMap.GetStringDirectionWithoutPoints(pointsPathesRequest);
            return Ok(returnString);
        }
    }
}