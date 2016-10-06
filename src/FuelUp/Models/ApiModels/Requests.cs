using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FuelUp.Models.ApiModels
{
    public class Requests
    {
        public class PathStrings
        {
            public string startPoint { set; get; }
            public string finishPoint { set; get; }
        }

        public class PathCoordinats
        {
            public Coordinates startPoint { set; get; }
            public Coordinates finishPoint { set; get; }
        }

        public class PathCoordinatsWithServiceCod :PathCoordinats
        {
            public long serviceCod { set; get; }
        }

        public class Filter
        {
            public long filters { set; get; }
        }

        public class PathCoordinatsWithFilter : PathCoordinats
        {
            public long filters { set; get; }
        }

        public class PathStringsWithFilter : PathStrings
        {
            public long filters { set; get; }
        }

        public class PathCoordinatsWithFilterAndWaypoints : PathCoordinatsWithFilter
        {
            public List<Coordinates> wayPoints { set; get; }
        }

        public class PathStringsWithFilterAndWaypoints : PathStringsWithFilter
        {
            public List<Coordinates> wayPoints { set; get; }
        }
    }
}
