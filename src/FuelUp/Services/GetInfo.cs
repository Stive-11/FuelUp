using FuelUp.Models.ApiModels;
using FuelUp.Models.DB;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FuelUp.Services
{
    public class GetInfo : IGetInfo
    {
        private readonly FuelUpContext _context;

        public GetInfo(
            FuelUpContext context
            )
        {
            _context = context;
        }

        public IEnumerable<MainInfoAzs> GetMainInfo()
        {
            var stations = _context.Stations.Select(x => new MainInfoAzs()
            {
                codFuels = x.Fuels,
                codServices = x.Services,
                coordinates = new Сoordinates()
                {
                    latitude = x.GPSN,
                    longitude = x.GPSE
                },
                name = x.Name,
                operatorName = x.Operator.NameRU
            });

            return stations;
        }

        public IEnumerable<MainInfoAzs> GetFilteredInfo(long filters)
        {
            var stations = _context.Stations
                .Where(x=> ((long) x.Services & filters) == filters)
                .Select(x => new MainInfoAzs()
                {
                    codFuels = x.Fuels,
                    codServices = x.Services,
                    coordinates = new Сoordinates()
                    {
                        latitude = x.GPSN,
                        longitude = x.GPSE
                    },
                    name = x.Name,
                    operatorName = x.Operator.NameRU
                });
            return stations;
        }

        public IEnumerable<MainInfoAzs> GetAllStationsWithFilterInfo(long filters)
        {
            var stations = _context.Stations
                .Where(x => ((long)x.Services | filters) == filters)
                .Select(x => new MainInfoAzs()
                {
                    codFuels = x.Fuels,
                    codServices = x.Services,
                    coordinates = new Сoordinates()
                    {
                        latitude = x.GPSN,
                        longitude = x.GPSE
                    },
                    name = x.Name,
                    operatorName = x.Operator.NameRU
                });
            return stations;
        }
    }
}