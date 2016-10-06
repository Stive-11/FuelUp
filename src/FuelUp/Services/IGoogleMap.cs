using System.Collections.Generic;
using FuelUp.Models.ApiModels;
using FuelUp.Models.Maps;

namespace FuelUp.Services
{
    public interface IGoogleMap
    {
        OneDirectionTwoPoints.RootObject GetDirectionWithoutPoints(Requests.PathStrings points);

        string GetStringDirectionWithoutPoints(Requests.PathStrings points);

        OneDirectionTwoPoints.RootObject GetDirectionWithoutPoints(Requests.PathCoordinats pointsPathesRequest);

        string GetStringDirectionWithoutPoints(Requests.PathCoordinats pointsPathesRequest);

        OneDirectionTwoPoints.RootObject GetDirectionWithWayPoints(Requests.PathStrings points, IEnumerable<Coordinates> wayPoints);

        string GetStringDirectionWithWayPoints(Requests.PathStrings points, IEnumerable<Coordinates> wayPoints);

        OneDirectionTwoPoints.RootObject GetDirectionWithWayPoints(Requests.PathCoordinats pointsPathesRequest, IEnumerable<Coordinates> wayPoints);

        string GetStringDirectionWithWayPoints(Requests.PathCoordinats pointsPathesRequest, IEnumerable<Coordinates> wayPoints);

    }
}