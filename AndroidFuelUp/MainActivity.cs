using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using AndroidFuelUp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
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

            // Get our button from the layout resource,
            // and attach an event to it

            GetServicesFromServer();

            Button button = FindViewById<Button>(Resource.Id.MyButton);

            //button.Click += delegate { GetMainInfoFromServer(); };

            Button theHiButton = FindViewById<Button>(Resource.Id.HiButton);
            theHiButton.Click += delegate
            {
                FunWithMap();
                GetTEstInfo();
            };

            ImageButton stationBtn = FindViewById<ImageButton>(Resource.Id.imageBtnStation);
            stationBtn.Click += delegate { theHiButton.Text = string.Format("{0}", GetString(Resource.String.ImgBtnStaition)); };

            
            Button menuButton = FindViewById<Button>(Resource.Id.menuButton);
             menuButton.Click += delegate { SendInfoToServer(); };

            Button testMenuButton = FindViewById<Button>(Resource.Id.testMenuButton);

            //testMenuButton.Click += delegate { GetServicesFromServer(); };

            testMenuButton.Click += delegate { StartActivity(typeof(TestMenuActivity)); };
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

                BitmapDescriptor image = BitmapDescriptorFactory.FromResource(Resource.Drawable.station);
                var bitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.station);
                var desc = BitmapDescriptorFactory.FromBitmap(bitmap);

                markerOpt1.InvokeIcon(desc);
                mMap.AddMarker(markerOpt1);
            }
        }

        public string GetMainInfoFromServer()
        {
            Android.Widget.Toast.MakeText(this,
                  "The Button to Server is clicked",
                  Android.Widget.ToastLength.Short).Show();

            var errorStr = string.Empty;

            //var sendingString = JsonConvert.SerializeObject(sendingPayout);
            var responseFromServer = string.Empty;

            try
            {
                //var encoding = new UTF8Encoding();
                //var body = encoding.GetBytes(sendingString);
                var url = @"http://193.124.57.9:2000/api/GetMainInfo";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/json";
                request.Method = "GET";
                //request.ContentLength = body.Length;
                //request.Headers.Add("Authentication", authentication);

                //using (Stream stream = request.GetRequestStream())
                //{
                //    stream.Write(body, 0, body.Length);
                //    stream.Close();
                //}

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    var strreader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    responseFromServer = strreader.ReadToEnd();
                    strreader.Close();
                }

                //var stations = JsonConvert.DeserializeObject<MainInfoAzs>(responseFromServer);

                Android.Widget.Toast.MakeText(this,
                   "The row #" + responseFromServer.ToString() + "is tappad",
                   Android.Widget.ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                return "Ошибка  #";
            }

            return responseFromServer;
        }

        public async void GetTEstInfo()
        {
            string getInfoUrl = "http://193.124.57.9:2000/api/GetMainInfo";
            HttpClient client = new HttpClient();            HttpResponseMessage response = await client.GetAsync(getInfoUrl);
            if (response.IsSuccessStatusCode)
            {
                Android.Widget.Toast.MakeText(this,
                  "Succes Http Respponse",
                  Android.Widget.ToastLength.Short).Show();

                //return await ParseResponse(response.Content);
            }
            else
            {
                Android.Widget.Toast.MakeText(this,
                  "ERROR Http Respponse",
                  Android.Widget.ToastLength.Short).Show();
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
                    //HttpResponseMessage response = await client.GetAsync(postServicesUrl);

                    var pointsPathesRequest = new Requests.PathStrings() { startPoint = "Minsk", finishPoint = "Brest" };
                    var json = JsonConvert.SerializeObject(pointsPathesRequest);
                    HttpResponseMessage response = await client.PostAsync(postStringServicesUrl, new StringContent(json, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        Android.Widget.Toast.MakeText(this,
                          await response.Content.ReadAsStringAsync(),
                          Android.Widget.ToastLength.Short).Show();

                        //return await ParseResponse(response.Content);
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
                      "Succes Http Respponse",
                      Android.Widget.ToastLength.Short).Show();
                    var json = await response.Content.ReadAsStringAsync();
                    var servicesFromDb = JsonConvert.DeserializeObject<List<ServiceTypes>>(json);
                    InfoStore.Services.Clear();
                    InfoStore.ServiceTypesInfo.AddRange(servicesFromDb);
                    foreach (var tempServ in servicesFromDb)
                    {
                        InfoStore.Services.Add(tempServ.Service);
                    }

                    // JsonConvert.SerializeObjectAsync(response.Content);

                    //return await ParseResponse(JsonConvert.ToString(response.Content));
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
                Android.Widget.Toast.MakeText(this,
                      strError,
                      Android.Widget.ToastLength.Long).Show();
            }
        }
    }
}