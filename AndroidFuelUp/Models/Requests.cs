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
    public class Requests
    {

        public class PathStrings
        {
            public string startPoint { set; get; }
            public string finishPoint { set; get; }
        }

        public class PathCoordinats
        {
            public Ñoordinates startPoint { set; get; }
            public Ñoordinates finishPoint { set; get; }
        }

        public class Filter
        {
            public long filters { get; set; }
        }

    }
}