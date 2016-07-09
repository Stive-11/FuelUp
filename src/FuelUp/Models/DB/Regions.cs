using System;
using System.Collections.Generic;

namespace FuelUp.Models.DB
{
    public partial class Regions
    {
        public Regions()
        {
            Cities = new HashSet<Cities>();
            Stations = new HashSet<Stations>();
        }

        public int ID { get; set; }
        public int? Type { get; set; }
        public string NameRU { get; set; }

        public virtual ICollection<Cities> Cities { get; set; }
        public virtual ICollection<Stations> Stations { get; set; }
    }
}
