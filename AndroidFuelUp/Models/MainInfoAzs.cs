namespace AndroidFuelUp.Models
{
    public class MainInfoAzs
    {
        public string name { set; get; }
        public Ñoordinates coordinates { set; get; }
        public long? codFuels { set; get; }
        public long? codServices { set; get; }
        public string operatorName { set; get; }
    }

    public class Ñoordinates
    {
        public double? latitude { set; get; }
        public double? longitude { set; get; }
    }

    public class StationForMap
    {
        public Ñoordinates coordinates { set; get; }
        public string operatorName { set; get; }

        public StationForMap(Ñoordinates coord, string oName)
        {
            coordinates = coord;
            operatorName = oName;
        }
    }
}