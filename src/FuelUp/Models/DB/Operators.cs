using System;
using System.Collections.Generic;

namespace FuelUp.Models.DB
{
    public partial class Operators
    {
        public Operators()
        {
            Stations = new HashSet<Stations>();
        }

        public int ID { get; set; }
        public string NameRU { get; set; }
        public string NameEN { get; set; }

        public virtual ICollection<Stations> Stations { get; set; }
    }
}
