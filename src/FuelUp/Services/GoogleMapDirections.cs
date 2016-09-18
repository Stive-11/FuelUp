using FuelUp.Models.ApiModels;
using FuelUp.Models.Maps;
using Newtonsoft.Json;

namespace FuelUp.Services
{
    public class GoogleMapDirections : IGoogleMap
    {
        private string _apiKey = string.Empty;

        public OneDirectionTwoPoints.RootObject GetDirectionWithoutPoints(Requests.PathStrings points)
        {
            var requestSender = new HttpRequestsGoogleMap(_apiKey);
            var responceString = requestSender.GetRouteTwoAdress(points).Result;
            return JsonConvert.DeserializeObject<OneDirectionTwoPoints.RootObject>(responceString);
        }

        public string GetStringDirectionWithoutPoints(Requests.PathStrings points)
        {
            var requestSender = new HttpRequestsGoogleMap(_apiKey);
            var responceString = requestSender.GetRouteTwoAdress(points).Result;
            return responceString;
        }

        public OneDirectionTwoPoints.RootObject GetDirectionWithoutPoints(Requests.PathCoordinats pointsPathesRequest)
        {
            var requestSender = new HttpRequestsGoogleMap(_apiKey);
            var responceString = requestSender.GetRouteTwoAdress(pointsPathesRequest).Result;
            return JsonConvert.DeserializeObject<OneDirectionTwoPoints.RootObject>(responceString);
        }

        public string GetStringDirectionWithoutPoints(Requests.PathCoordinats pointsPathesRequest)
        {
            var requestSender = new HttpRequestsGoogleMap(_apiKey);
            var responceString = requestSender.GetRouteTwoAdress(pointsPathesRequest).Result;
            return responceString;
        }
    }
}