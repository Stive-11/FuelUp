using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuelUp.Models.Maps;

namespace FuelUp.Models.ApiModels
{
    public class Responce
    {
        public class PathAndStations
        {
            public OneDirectionTwoPoints.RootObject path { set; get; }
            public IEnumerable<MainInfoAzs> stations { set; get; }
        }
    }
}
