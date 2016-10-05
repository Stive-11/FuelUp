namespace FuelUp.Models.ApiModels
{
    public class MainInfoAzs
    {
        public string name { set; get; }
        public Сoordinates coordinates { set; get; }
        public int? codFuels { set; get; }
        public int? codServices { set; get; }
        public string operatorName { set; get; }

        public override bool Equals(object obj)
        {
            // If parameter cannot be cast to Point return false.
            var p = obj as MainInfoAzs;
            if ((object)p == null)
            {
                return false;
            }
            if (coordinates.latitude == null || coordinates.longitude == null || p.coordinates.latitude == null ||
                p.coordinates.longitude == null)
                return false;
            // Return true if the fields match:
            return (coordinates.latitude == p.coordinates.latitude) && (coordinates.longitude == p.coordinates.longitude);
        }

        public bool Equals(MainInfoAzs p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }
            if (coordinates.latitude == null || coordinates.longitude == null || p.coordinates.latitude == null ||
                 p.coordinates.longitude == null)
                return false;
            // Return true if the fields match:
            return (coordinates.latitude == p.coordinates.latitude) && (coordinates.longitude == p.coordinates.longitude);
        }

        public override int GetHashCode()
        {
            return (int)(coordinates.latitude * 1000000 + coordinates.longitude * 1000000);
        }
    }

    public class Сoordinates
    {
        public double? latitude { set; get; }
        public double? longitude { set; get; }
    }
}