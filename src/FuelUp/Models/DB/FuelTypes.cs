using System;
using System.Collections.Generic;

namespace FuelUp.Models.DB
{
    public partial class FuelTypes
    {
        public int ID { get; set; }
        public string FuelName { get; set; }
        public int? FuelCode { get; set; }
    }
}
