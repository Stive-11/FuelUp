using FuelUp.Models.ApiModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FuelUp.Services
{
    public class HttpRequestsGoogleMap
    {
        private const string GoogleAdress = "https://maps.googleapis.com/maps/api/directions/json?origin=";
        private readonly string _apiKey;

        public HttpRequestsGoogleMap(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<string> GetRouteTwoAdress(Requests.PathStrings paths)
        {
            var url = GetRequestAdressTwoPoints(paths.startPoint, paths.finishPoint);
            return await SendRequest(url);
        }

        public async Task<string> GetRouteTwoAdress(Requests.PathStrings paths, IEnumerable<Сoordinates> waypoints)
        {
            var url = GetRequestAdressTwoPoints(paths.startPoint, paths.finishPoint);
            url = AddWaypoints(waypoints, url);
            return await SendRequest(url);
        }

        public async Task<string> GetRouteTwoAdressAlternative(Requests.PathStrings paths)
        {
            var url = AddAlternativeDirections(GetRequestAdressTwoPoints(paths.startPoint, paths.finishPoint));
            return await SendRequest(url);
        }

        public async Task<string> GetRouteTwoAdress(Requests.PathCoordinats paths)
        {
            var url = GetRequestAdressTwoPoints(paths);
            return await SendRequest(url);
        }

        public async Task<string> GetRouteTwoAdress(Requests.PathCoordinats paths, IEnumerable<Сoordinates> waypoints)
        {
            var url = GetRequestAdressTwoPoints(paths);
            url = AddWaypoints(waypoints, url);
            return await SendRequest(url);
        }

        public async Task<string> GetRouteTwoAdressAlternative(Requests.PathCoordinats paths)
        {
            var url = AddAlternativeDirections(GetRequestAdressTwoPoints(paths));
            return await SendRequest(url);
        }

        private string AddApiKey(string url)
        {
            return _apiKey.Equals(string.Empty) ? url : $"{url}&key={_apiKey}";
        }

        private async Task<string> SendRequest(string url)
        {
            var client = new HttpClient();
            var responseFromServer = await client.GetStringAsync(AddApiKey(url));
            return responseFromServer;
        }

        private static string GetRequestAdressTwoPoints(string adressStart, string adressFinish)
        {
            return $"{GoogleAdress}{adressStart}&destination={adressFinish}";
        }

        private static string AddAlternativeDirections(string url)
        {
            return $"{ url }&alternatives=true";
        }

        private static string GetAdressFromCoordinates(Сoordinates coordinates)
        {
            return $"{DoubleToString(coordinates.latitude)},{DoubleToString(coordinates.longitude)}";
        }

        private static string GetRequestAdressTwoPoints(Requests.PathCoordinats coordinats)
        {
            var startAdress = GetAdressFromCoordinates(coordinats.startPoint);
            var finishAdress = GetAdressFromCoordinates(coordinats.finishPoint);
            return $"{GetRequestAdressTwoPoints(startAdress, finishAdress)}";
        }

        private string AddWaypoints(IEnumerable<Сoordinates> waypoints, string url)
        {
            var resultString = $"{url}&waypoints=";
            foreach (var waypoint in waypoints)
            {
                resultString += $"{GetAdressFromCoordinates(waypoint)}|";
            }
            return resultString.Remove(resultString.Length - 1, 1);
        }

        private static string DoubleToString(double? x)
        {
            return x.ToString().Replace(',', '.');
        }
    }
}