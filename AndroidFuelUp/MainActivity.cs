using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;

namespace AndroidFuelUp
{
    [Activity(Label = "AndroidFuelUp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnMapReadyCallback
    {
        int count = 1;

        private GoogleMap mMap;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            SetUpMap();

           

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };


            Button theHiButton = FindViewById<Button>(Resource.Id.HiButton);

            ImageButton stationBtn = FindViewById<ImageButton>(Resource.Id.imageBtnStation);

            stationBtn.Click += delegate { theHiButton.Text = string.Format("{0}", GetString(Resource.String.ImgBtnStaition)); };

        }

        private void SetUpMap()
        {
            if (mMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }


        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;

            //throw new NotImplementedException();
        }
    }
}

