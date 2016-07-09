using System;
using System.Collections.Generic;

namespace FuelUp.Models.DB
{
    public partial class ObjectTypes
    {
        public ObjectTypes()
        {
            Stations = new HashSet<Stations>();
        }

        public int ID { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Stations> Stations { get; set; }
    }
}
