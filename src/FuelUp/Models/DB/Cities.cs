using System;
using System.Collections.Generic;

namespace FuelUp.Models.DB
{
    public partial class Cities
    {
        public Cities()
        {
            Stations = new HashSet<Stations>();
        }

        public int ID { get; set; }
        public string CItyName { get; set; }
        public int? RegionID { get; set; }
        public int? CItyTypeID { get; set; }
        public string PhoneCode { get; set; }

        public virtual ICollection<Stations> Stations { get; set; }
        public virtual CityTypes CItyType { get; set; }
        public virtual Regions Region { get; set; }
    }
}
