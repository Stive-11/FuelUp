using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelUp.Models.ApiModels
{
    public class MainInfoAzs
    {
        public string name { set; get; }
        public Сoordinates coordinates { set; get; }
        public int? codFuels { set; get; }
        public int? codServices { set; get; }
        public string operatorName { set; get; }

    }

    public class Сoordinates
    {
        public double? latitude { set; get; }
        public double? longitude { set; get; }
    }
}
