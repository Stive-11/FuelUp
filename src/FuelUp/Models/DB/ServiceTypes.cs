using System;
using System.Collections.Generic;

namespace FuelUp.Models.DB
{
    public partial class ServiceTypes
    {
        public int ID { get; set; }
        public string Service { get; set; }
        public int? Code { get; set; }
    }
}
