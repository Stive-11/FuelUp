namespace AndroidFuelUp.Models
{
    internal class TestRouteClass
    {
        public class rootobject
        {
            public geocoded_waypoints[] geocoded_waypoints { get; set; }
            public routes[] routeses { get; set; }
            public string status { get; set; }
        }

        public class geocoded_waypoints
        {
            public string geocoder_status { get; set; }
            public string place_id { get; set; }
            public string[] types { get; set; }
        }

        public class routes
        {
            public bounds bounds { get; set; }
            public string copyrights { get; set; }
            public legs[] Legses { get; set; }
            public overview_polyline overview_polyline { get; set; }
            public string summary { get; set; }
            public object[] warnings { get; set; }
            public object[] waypoint_order { get; set; }
        }

        public class bounds
        {
            public northeast northeast { get; set; }
            public southwest southwest { get; set; }
        }

        public class northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class overview_polyline
        {
            public string points { get; set; }
        }

        public class legs
        {
            public distance distance { get; set; }
            public duration duration { get; set; }
            public string end_address { get; set; }
            public end_location end_location { get; set; }
            public string start_address { get; set; }
            public start_location start_location { get; set; }
            public steps[] stepses { get; set; }
            public object[] traffic_speed_entry { get; set; }
            public object[] via_waypoint { get; set; }
        }

        public class distance
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class duration
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class end_location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class start_location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class steps
        {
            public distance distance { get; set; }
            public duration duration { get; set; }
            public end_location end_location { get; set; }
            public string html_instructions { get; set; }
            public polyline polyline { get; set; }
            public start_location start_location { get; set; }
            public string travel_mode { get; set; }
            public string maneuver { get; set; }
        }

        public class polyline
        {
            public string points { get; set; }
        }
    }
}