using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidFuelUp.Models
{
    public class Responce
    {
        public class PathAndStations
        {
            public OneDirectionTwoPoints.RootObject path { set; get; }
            public List<StationForMap> stations { set; get; }
        }
    }
}