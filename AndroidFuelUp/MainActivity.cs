using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

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
            theHiButton.Click += delegate { FunWithMap(); };

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


        public void FunWithMap()
        {
            if (mMap != null)
            {
                mMap.MapType = GoogleMap.MapTypeNormal;

                LatLng location = new LatLng(53.87615, 27.6739);
                CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
                builder.Target(location);
                builder.Zoom(18);
                //builder.Bearing(155);
                //builder.Tilt(65);
                CameraPosition cameraPosition = builder.Build();
                CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

                mMap.MoveCamera(cameraUpdate);
                //Marker marker1=new Marker();

                MarkerOptions markerOpt1 = new MarkerOptions();
                markerOpt1.SetPosition(new LatLng(53.87615, 27.6739));
                markerOpt1.SetTitle("MINSK");
                //markerOpt1.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueCyan));
                mMap.AddMarker(markerOpt1);

            }
        }
    }
}

