using System.Collections.Generic;

namespace AndroidFuelUp.Models
{
    public static class InfoStore
    {
        public static List<string> Services { get; set; }
        public static List<MainInfoAzs> InfoAzs { get; set; }
        public static List<ServiceTypes> ServiceTypesInfo { set; get; }
        public static List<StationForMap> StationsOnMap { set; get; }
        public static long SelectedServiceCod { set; get; }

        public static string StartPoint { get; set; }
        public static string FinishPoint { get; set; }

        static InfoStore()
        {
            Services = new List<string>() { string.Empty };
            InfoAzs = new List<MainInfoAzs>();
            ServiceTypesInfo = new List<ServiceTypes>();
            StationsOnMap = new List<StationForMap>();
            SelectedServiceCod = new long();
            StartPoint = string.Empty;
            FinishPoint = string.Empty;
        }
    }
}