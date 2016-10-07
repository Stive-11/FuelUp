using FuelUp.Models.ApiModels;
using FuelUp.Models.Maps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuelUp.Services
{
    public class CheckStationForPath
    {
        private readonly OneDirectionTwoPoints.RootObject _path;
        private readonly IEnumerable<MainInfoAzs> _stations;
        private readonly Coordinates _distance;
        private readonly List<Bound> _bounds;

        public CheckStationForPath(OneDirectionTwoPoints.RootObject path, Coordinates distance,
            IEnumerable<MainInfoAzs> stations)
        {
            _path = path;
            _stations = stations;
            _distance = distance;

            _bounds = CreateBounds();
        }

        public IEnumerable<MainInfoAzs> GetStations()
        {
            var listStations = CheckStations();
            return listStations.Distinct();
        }

        private IEnumerable<MainInfoAzs> CheckStations()
        {
            try
            {
                return (from bound in _bounds from station in _stations where bound.IsInBound(station.coordinates) select station).ToList();
            }
            catch (Exception)
            {
                return new List<MainInfoAzs>();
            }
        }

        private List<Bound> CreateBounds()
        {
            var bounds = new List<Bound>();
            foreach (var step in _path.routes[0].legs[0].steps)
            {
                var point1 = new Coordinates()
                {
                    latitude = step.start_location.lat,
                    longitude = step.start_location.lng
                };
                var point2 = new Coordinates()
                {
                    latitude = step.end_location.lat,
                    longitude = step.end_location.lng
                };
                bounds.Add(new Bound(point1, point2, _distance));
            }
            return bounds;
        }

        private class Bound
        {
            private readonly Coordinates _leftBound;
            private readonly Coordinates _rightBound;

            //private const double koef = 1.6;
            private double _maxDistance;

            private readonly Coordinates _point1;
            private readonly Coordinates _point2;
            //private readonly Coordinates _distance;

            public Bound(Coordinates point1, Coordinates point2, Coordinates distance)
            {
                _leftBound = new Coordinates()
                {
                    latitude = point1.latitude < point2.latitude ? point1.latitude : point2.latitude,
                    longitude = point1.longitude < point2.longitude ? point1.longitude : point2.longitude
                };
                _rightBound = new Coordinates()
                {
                    latitude = point1.latitude >= point2.latitude ? point1.latitude : point2.latitude,
                    longitude = point1.longitude >= point2.longitude ? point1.longitude : point2.longitude
                };

                _leftBound.latitude -= distance.latitude;
                _leftBound.longitude -= distance.longitude;
                _rightBound.latitude += distance.latitude;
                _rightBound.longitude += distance.longitude;
                // _maxDistance = (double)(1.4 * (distance.latitude + distance.longitude * koef));

                _point1 = point1;
                _point2 = point2;
                //_distance = distance;
            }

            public bool IsInBound(Coordinates point)
            {
                if (point.longitude == null || point.latitude == null)
                    return false;
                if (point.latitude < _leftBound.latitude || point.latitude > _rightBound.latitude)
                    return false;
                if (point.longitude < _leftBound.longitude || point.longitude > _rightBound.longitude)
                    return false;

                var a = (_point1.longitude - _point2.longitude);
                var b = (_point2.latitude - _point1.latitude);
                var c = (_point1.latitude * _point2.longitude - _point2.latitude * _point1.longitude);
                var ab = (double)(a * a + b * b);
                var d = Math.Abs((double)(a * point.latitude + b * point.longitude + c) / Math.Sqrt(ab));
                _maxDistance = 0.12;
                return (d < _maxDistance);
            }
        }
    }
}