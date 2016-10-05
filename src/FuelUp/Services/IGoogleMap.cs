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
    }
}