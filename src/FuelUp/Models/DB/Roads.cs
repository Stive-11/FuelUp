using System;
using System.Collections.Generic;

namespace FuelUp.Models.DB
{
    public partial class Roads
    {
        public int ID { get; set; }
        public string RoadNameRU { get; set; }
        public string RoadNameEN { get; set; }
        public string RoadCode1 { get; set; }
        public string RoadCode2 { get; set; }
    }
}
