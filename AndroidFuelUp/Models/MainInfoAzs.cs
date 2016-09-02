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
    public class MainInfoAzs
    {
        public string name { set; get; }
        public Ñoordinates coordinates { set; get; }
        public int? codFuels { set; get; }
        public int? codServices { set; get; }
        public string operatorName { set; get; }

    }

    public class Ñoordinates
    {
        public double? latitude { set; get; }
        public double? longitude { set; get; }
    }
}