using FuelUp.Models.ApiModels;
using FuelUp.Models.Maps;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FuelUp.Services
{
    public class GoogleMapDirections : IGoogleMap
    {
        private readonly string _apiKey;

        public GoogleMapDirections(GoogleApiKey googleApiKey)
        {
            _apiKey = googleApiKey.Key;
        }

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

        public OneDirectionTwoPoints.RootObject GetDirectionWithWayPoints(Requests.PathStrings points, IEnumerable<Coordinates> wayPoints)
        {
            var requestSender = new HttpRequestsGoogleMap(_apiKey);
            var responceString = requestSender.GetRouteTwoAdress(points, wayPoints).Result;
            return JsonConvert.DeserializeObject<OneDirectionTwoPoints.RootObject>(responceString);
        }

        public string GetStringDirectionWithWayPoints(Requests.PathStrings points, IEnumerable<Coordinates> wayPoints)
        {
            var requestSender = new HttpRequestsGoogleMap(_apiKey);
            var responceString = requestSender.GetRouteTwoAdress(points, wayPoints).Result;
            return responceString;
        }

        public OneDirectionTwoPoints.RootObject GetDirectionWithWayPoints(Requests.PathCoordinats pointsPathesRequest, IEnumerable<Coordinates> wayPoints)
        {
            var requestSender = new HttpRequestsGoogleMap(_apiKey);
            var responceString = requestSender.GetRouteTwoAdress(pointsPathesRequest, wayPoints).Result;
            return JsonConvert.DeserializeObject<OneDirectionTwoPoints.RootObject>(responceString);
        }

        public string GetStringDirectionWithWayPoints(Requests.PathCoordinats pointsPathesRequest, IEnumerable<Coordinates> wayPoints)
        {
            var requestSender = new HttpRequestsGoogleMap(_apiKey);
            var responceString = requestSender.GetRouteTwoAdress(pointsPathesRequest, wayPoints).Result;
            return responceString;
        }
    }
}