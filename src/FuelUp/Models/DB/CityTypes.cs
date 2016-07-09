using System;
using System.Collections.Generic;

namespace FuelUp.Models.DB
{
    public partial class CityTypes
    {
        public CityTypes()
        {
            Cities = new HashSet<Cities>();
        }

        public int ID { get; set; }
        public int? TypeID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Cities> Cities { get; set; }
    }
}
