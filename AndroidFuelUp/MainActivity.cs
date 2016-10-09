using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidFuelUp.Core;
using AndroidFuelUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

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
                // GetInfoFromServer();
                ShowAllStationOnMap();
            };

            Button routeButton = FindViewById<Button>(Resource.Id.routeBtn);
            routeButton.Click += delegate
            {
                //SendInfoToServer();
                GetRouteWithFilter();
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
                    InfoStore.StartPoint = edittextStartPoint.Text;
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
                    InfoStore.FinishPoint = edittextFinishPoint.Text;
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
            if (InfoStore.InfoAzsWithFilter.Count < 2)
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
                            InfoStore.StationsOnMap.Add(new StationForMap(tempStation.coordinates,
                                tempStation.operatorName, tempStation.codServices));
                        }
                        //Выбираем все доступные сервисы для переменной фильтра
                        InfoStore.SelectedServiceCod = ServiceDecoder.GetServicesCod(InfoStore.Services);
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
        }

        public async void SendInfoToServer()
        {
            try
            {
                string postStringServicesUrl = "http://193.124.57.9:2000/api/Pathes/stringsPath";

                using (HttpClient client = new HttpClient())
                {
                    var pointsPathesRequest = new Requests.PathStrings()
                    {
                        startPoint = InfoStore.StartPoint,
                        finishPoint = InfoStore.FinishPoint
                    };

                    Android.Widget.Toast.MakeText(this,
                          "Please wait while route is downloading...",
                          Android.Widget.ToastLength.Short).Show();

                    var json = JsonConvert.SerializeObject(pointsPathesRequest);
                    HttpResponseMessage response = await client.PostAsync(postStringServicesUrl, new StringContent(json, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        var routeJson = await response.Content.ReadAsStringAsync();
                        var routeInfo = JsonConvert.DeserializeObject<OneDirectionTwoPoints.RootObject>(routeJson);
                        InfoStore.RouteInfo = routeInfo;

                        // Show current route on map
                        ShowRouteOnMap();
                        ShowStartFinishPointOnMap();

                        string str = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        Android.Widget.Toast.MakeText(this,
                          "ERROR Http Response",
                          Android.Widget.ToastLength.Long).Show();
                    }
                }
            }
            catch (Exception ex)
            {
                //var errormessage = $"{ex.Message} \n {ex.StackTrace}";
                //Android.Widget.Toast.MakeText(this,
                //      errormessage,
                //      Android.Widget.ToastLength.Long).Show();
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
            Android.Widget.Toast.MakeText(this,
                     InfoStore.SelectedServiceCod.ToString(),
                     Android.Widget.ToastLength.Long).Show();

            foreach (var station in InfoStore.StationsOnMap)
            {
                if (station.coordinates.latitude != null && station.coordinates.longitude != null)
                    MakeStationOnMap(new LatLng((double)station.coordinates.latitude,
                            (double)station.coordinates.longitude),
                        station.operatorName);
            }
        }

        public void ShowRouteOnMap()
        {
            var newRoute = new PolylineOptions().Visible(true).InvokeColor(Color.BlueViolet).InvokeWidth(7);

            //Adding start point to route
            newRoute.Add(new LatLng(InfoStore.RouteInfo.routes[0].legs[0].start_location.lat,
                InfoStore.RouteInfo.routes[0].legs[0].start_location.lng));

            //Adding midpoints
            foreach (var currentPoints in InfoStore.RouteInfo.routes[0].legs[0].steps)
            {
                var listOfCurrentCoord = PolylineDecode.DecodePolylinePoints(currentPoints.polyline.points);
                foreach (var pointToMap in listOfCurrentCoord)
                {
                    newRoute.Add(new LatLng((double)pointToMap.latitude,
                        (double)pointToMap.longitude));
                }
            }

            //Adding finish point to route
            newRoute.Add(new LatLng(InfoStore.RouteInfo.routes[0].legs[0].end_location.lat,
                InfoStore.RouteInfo.routes[0].legs[0].end_location.lng));
            mMap.Clear();
            mMap.AddPolyline(newRoute);
        }

        public void ShowStartFinishPointOnMap()
        {
            mMap.MapType = GoogleMap.MapTypeNormal;

            MarkerOptions startMarkerOptions = new MarkerOptions();
            MarkerOptions finishMarkerOptions = new MarkerOptions();
            //Set coord of start point
            startMarkerOptions.SetPosition(new LatLng(InfoStore.RouteInfo.routes[0].legs[0].start_location.lat,
               InfoStore.RouteInfo.routes[0].legs[0].start_location.lng));
            //Set coord of end point
            finishMarkerOptions.SetPosition(new LatLng(InfoStore.RouteInfo.routes[0].legs[0].end_location.lat,
               InfoStore.RouteInfo.routes[0].legs[0].end_location.lng));
            //Set name to and/start point
            startMarkerOptions.SetTitle(InfoStore.RouteInfo.routes[0].legs[0].start_address);
            finishMarkerOptions.SetTitle(InfoStore.RouteInfo.routes[0].legs[0].end_address);

            //Set the marker of point
            startMarkerOptions.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueCyan));
            finishMarkerOptions.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueGreen));

            mMap.AddMarker(startMarkerOptions);
            mMap.AddMarker(finishMarkerOptions);
        }

        public async void GetRouteWithFilter()
        {
            try
            {
                string postStringServicesWithFilterUrl = "http://193.124.57.9:2000/api/Pathes/stringsPathWithFilters";

                using (HttpClient client = new HttpClient())
                {
                    var pointsPathesWithFilterRequest = new Requests.PathStringsWithFilter()
                    {
                        filters = InfoStore.SelectedServiceCod,
                        startPoint = InfoStore.StartPoint,
                        finishPoint = InfoStore.FinishPoint
                    };

                    
                    var json = JsonConvert.SerializeObject(pointsPathesWithFilterRequest);
                    var response = await client.PostAsync(postStringServicesWithFilterUrl, new StringContent(json, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        var routeJson = await response.Content.ReadAsStringAsync();
                        var routeInfoWithFilter = JsonConvert.DeserializeObject<Responce.PathAndStations>(routeJson);
                        InfoStore.RouteInfo = routeInfoWithFilter.path;
                        InfoStore.StationsOnMap = routeInfoWithFilter.stations;

                        // Show current route on map
                        ShowRouteOnMap();
                        ShowStartFinishPointOnMap();
                        ShowAllStationOnMap();


                        string str = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        Android.Widget.Toast.MakeText(this,
                          "ERROR Http Response",
                          Android.Widget.ToastLength.Long).Show();
                    }
                }
            }
            catch (Exception ex)
            {
                //var errormessage = $"{ex.Message} \n {ex.StackTrace}";
                //Android.Widget.Toast.MakeText(this,
                //      errormessage,
                //      Android.Widget.ToastLength.Long).Show();
            }
        }

    }
}