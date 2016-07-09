using System;
using System.Collections.Generic;

namespace FuelUp.Models.DB
{
    public partial class Stations
    {
        public int ID { get; set; }
        public int? Center { get; set; }
        public int? Number { get; set; }
        public string Name { get; set; }
        public int? TypeID { get; set; }
        public int? CityID { get; set; }
        public string Phone { get; set; }
        public int? Fuels { get; set; }
        public int? Services { get; set; }
        public string OpenHours { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int? TrackID { get; set; }
        public int? Status { get; set; }
        public int? CountryID { get; set; }
        public int? RegionID { get; set; }
        public double? GPSN { get; set; }
        public double? GPSE { get; set; }
        public string Adress { get; set; }
        public string OperatorName { get; set; }
        public int? Prioritet { get; set; }
        public int? FolderType { get; set; }
        public int? OperatorID { get; set; }

        public virtual Cities City { get; set; }
        public virtual Operators Operator { get; set; }
        public virtual Regions Region { get; set; }
        public virtual ObjectTypes Type { get; set; }
    }
}
