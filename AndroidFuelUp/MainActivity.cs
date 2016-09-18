using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidFuelUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;using System.Text;

namespace AndroidFuelUp
{
    [Activity(Label = "AndroidFuelUp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnMapReadyCallback
    {
        private GoogleMap mMap;
        private List<string> resault = new List<string>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            SetUpMap();

            GetServicesFromServer();
            GetInfoFromServer();

            Button showStationsButton = FindViewById<Button>(Resource.Id.showStationsBtn);
            showStationsButton.Click += delegate
            {
                GetInfoFromServer();
                ShowAllStationOnMap();
            };

           

            Button routeButton = FindViewById<Button>(Resource.Id.routeBtn);
            routeButton.Click += delegate
            {
                SendInfoToServer();
            };

            Button serviceMenuButton = FindViewById<Button>(Resource.Id.testMenuButton);
            serviceMenuButton.Click += delegate
            {
                StartActivity(typeof(MenuActivity));
            };

            EditText edittextStartPoint = FindViewById<EditText>(Resource.Id.edittextStartPoint);
            edittextStartPoint.KeyPress += (object sender, View.KeyEventArgs e) =>
            {
                e.Handled = false;
                if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                {
                    Toast.MakeText(this, edittextStartPoint.Text, ToastLength.Short).Show();
                    e.Handled = true;
                }
            };

            EditText edittextFinishPoint = FindViewById<EditText>(Resource.Id.edittextFinishPoint);
            edittextFinishPoint.KeyPress += (object sender, View.KeyEventArgs e) =>
            {
                e.Handled = false;
                if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
                {
                    Toast.MakeText(this, edittextFinishPoint.Text, ToastLength.Short).Show();
                    e.Handled = true;
                }
            };
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
            LatLngBounds bounds = new LatLngBounds(
                new LatLng(51.230751, 23.178335),
                new LatLng(56.173565, 32.776834));
            mMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(bounds.Center, (float)5.5));
            mMap.UiSettings.ZoomControlsEnabled = true;
            mMap.UiSettings.CompassEnabled = true;
        }

        

        public async void GetInfoFromServer()
        {
            try
            {
                string getInfoUrl = "http://193.124.57.9:2000/api/GetMainInfo";
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(getInfoUrl);

                if (response.IsSuccessStatusCode)
                {
                    Android.Widget.Toast.MakeText(this,
                      "SuccesGetMainInfoRespponse",
                      Android.Widget.ToastLength.Short).Show();
                    var json = await response.Content.ReadAsStringAsync();
                    var infoAboutAzs = JsonConvert.DeserializeObject<List<MainInfoAzs>>(json);
                    InfoStore.InfoAzs.Clear();
                    InfoStore.InfoAzs.AddRange(infoAboutAzs);
                    foreach (var tempStation in infoAboutAzs)
                    {
                        InfoStore.StationsOnMap.Add(new StationForMap(tempStation.coordinates, tempStation.operatorName));
                    }
                }
                else
                {
                    Android.Widget.Toast.MakeText(this,
                      "ERROR Http Respponse",
                      Android.Widget.ToastLength.Short).Show();
                }
            }
            catch (System.Exception ex)
            {
                var strError = $"{ex.ToString()} {ex.Message} {ex.StackTrace} ";
                //Android.Widget.Toast.MakeText(this,
                //      strError,
                //      Android.Widget.ToastLength.Long).Show();
            }
        }

        public async void SendInfoToServer()
        {
            try
            {
                string postStringServicesUrl = "http://193.124.57.9:2000/api/Pathes/stringsPath";
                string postCoordServiceUrl = "http://193.124.57.9:2000/api/Pathes/coordinatsPath";

                using (HttpClient client = new HttpClient())
                {
                    var pointsPathesRequest = new Requests.PathStrings() { startPoint = "Minsk", finishPoint = "Brest" };
                    var json = JsonConvert.SerializeObject(pointsPathesRequest);
                    HttpResponseMessage response = await client.PostAsync(postStringServicesUrl, new StringContent(json, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        Android.Widget.Toast.MakeText(this,
                          await response.Content.ReadAsStringAsync(),
                          Android.Widget.ToastLength.Short).Show();
                    }
                    else
                    {
                        Android.Widget.Toast.MakeText(this,
                          "ERROR Http Response",
                          Android.Widget.ToastLength.Short).Show();
                    }
                }
            }
            catch (Exception ex)
            {
                var errormessage = $"{ex.Message} \n {ex.StackTrace}";
                Android.Widget.Toast.MakeText(this,
                      errormessage,
                      Android.Widget.ToastLength.Short).Show();
            }
        }

        public async void GetServicesFromServer()
        {
            try
            {
                string getServicesUrl = "http://193.124.57.9:2000/api/GetServiceTypes";
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(getServicesUrl);

                if (response.IsSuccessStatusCode)
                {
                    Android.Widget.Toast.MakeText(this,
                      "SuccesServicesResponse",
                      Android.Widget.ToastLength.Short).Show();
                    var json = await response.Content.ReadAsStringAsync();
                    var servicesFromDb = JsonConvert.DeserializeObject<List<ServiceTypes>>(json);
                    InfoStore.Services.Clear();
                    InfoStore.ServiceTypesInfo.AddRange(servicesFromDb);
                    foreach (var tempServ in servicesFromDb)
                    {
                        InfoStore.Services.Add(tempServ.Service);
                    }
                }
                else
                {
                    Android.Widget.Toast.MakeText(this,
                      "ERROR Http Respponse",
                      Android.Widget.ToastLength.Short).Show();
                }
            }
            catch (System.Exception ex)
            {
                var strError = $"{ex.ToString()} {ex.Message} {ex.StackTrace} ";
                //Android.Widget.Toast.MakeText(this,
                //      strError,
                //      Android.Widget.ToastLength.Long).Show();
            }
        }

        //Нанесение на карту одной заправочной станции
        public void MakeStationOnMap(LatLng location, string operatorName)
        {
            if (mMap != null)
            {
                mMap.MapType = GoogleMap.MapTypeNormal;

                MarkerOptions newStatioinMarker = new MarkerOptions();
                newStatioinMarker.SetPosition(location);
                newStatioinMarker.SetTitle(operatorName);

                BitmapDescriptor image = BitmapDescriptorFactory.FromResource(Resource.Drawable.station);
                var bitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.station);
                var desc = BitmapDescriptorFactory.FromBitmap(bitmap);

                newStatioinMarker.InvokeIcon(desc);
                mMap.AddMarker(newStatioinMarker);
            }
        }

        //Отображение на карте всех станций из базы данных
        public void ShowAllStationOnMap()
        {
            foreach (var station in InfoStore.StationsOnMap)
            {
                if (station.coordinates.latitude != null && station.coordinates.longitude != null)
                    MakeStationOnMap(new LatLng((double)station.coordinates.latitude,
                            (double)station.coordinates.longitude),
                        station.operatorName);
            }
        }
    }
}