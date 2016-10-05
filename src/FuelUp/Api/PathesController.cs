using FuelUp.Models.ApiModels;
using FuelUp.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FuelUp.Api
{
    [Produces("application/json")]
    public class PathesController : Controller
    {
        private readonly IGoogleMap _googleMap;
        private readonly IGetInfo _getInfo;
        private readonly Ñoordinates _distance;

        public PathesController(
            IGoogleMap googleMap,
            IGetInfo getInfo,
            Ñoordinates distance
            )
        {
            _googleMap = googleMap;
            _getInfo = getInfo;
            _distance = distance;
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

        [Route("api/Pathes/stringsPathWithFilters")]
        [HttpPost]
        public IActionResult StringPathesWithFilters([FromBody] Requests.PathStringsWithFilter pointsPathesRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var path = _googleMap.GetDirectionWithoutPoints(pointsPathesRequest);
            var stations = _getInfo.GetAllStationsWithFilterInfo(pointsPathesRequest.filters);
            
            var checkerStations = new CheckStationForPath(path, _distance, stations);
            var result = new Responce.PathAndStations()
            {
                path = path,
                stations = checkerStations.GetStations()
            };
            var returnString = JsonConvert.SerializeObject(result);
            return Ok(returnString);
        }


        [Route("api/Pathes/coordinatsPathWithFilters")]
        [HttpPost]
        public IActionResult CoordinatsPathesWithFilters([FromBody] Requests.PathCoordinatsWithFilter pointsPathesRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var path = _googleMap.GetDirectionWithoutPoints(pointsPathesRequest);
            var stations = _getInfo.GetAllStationsWithFilterInfo(pointsPathesRequest.filters);

            var checkerStations = new CheckStationForPath(path, _distance, stations);
            var result = new Responce.PathAndStations()
            {
                path = path,
                stations = checkerStations.GetStations()
            };
            var returnString = JsonConvert.SerializeObject(result);
            return Ok(returnString);
        }

    }
}