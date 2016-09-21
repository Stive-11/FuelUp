using Java.Lang;

namespace AndroidFuelUp.Models
{
    public class MainInfoAzs
    {
        public string name { set; get; }
        public �oordinates coordinates { set; get; }
        public long? codFuels { set; get; }
        public long? codServices { set; get; }
        public string operatorName { set; get; }
    }

    public class �oordinates
    {
        public double? latitude { set; get; }
        public double? longitude { set; get; }
    }

    public class StationForMap
    {
        public �oordinates coordinates { set; get; }
        public string operatorName { set; get; }
        public long? codServices { set; get; }

        public StationForMap(�oordinates coord, string oName, long? cServices)
        {
            coordinates = coord;
            operatorName = oName;
            codServices = cServices;
        }
    }
}