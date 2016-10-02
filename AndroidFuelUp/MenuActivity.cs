using System;
using Android.App;
using Android.OS;
using Android.Widget;
using AndroidFuelUp.Core;
using AndroidFuelUp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace AndroidFuelUp
{
    [Activity(Label = "MenuActivity")]
    public class MenuActivity : Activity
    {
        private List<string> resault = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ServicesMenu);

            var menuListView = FindViewById<ListView>(Resource.Id.listViewMenu);
            menuListView.Adapter = new ArrayAdapter<string>(this,
                Android.Resource.Layout.SimpleListItemMultipleChoice, InfoStore.Services.ToArray());

            menuListView.ChoiceMode = ChoiceMode.Multiple;

            Button doneButton = FindViewById<Button>(Resource.Id.doneButton);

            doneButton.Click += delegate
            {
                var checkedList = new List<string>();
                var arrayServices = InfoStore.Services.ToArray();
                var sparseArray = menuListView.CheckedItemPositions;

                for (var i = 0; i < sparseArray.Size(); i++)
                {
                    var key = sparseArray.Get(sparseArray.KeyAt(i));
                    if (key)
                        checkedList.Add(arrayServices[sparseArray.KeyAt(i)]);
                }

                InfoStore.SelectedServiceCod = ServiceDecoder.GetServicesCod(checkedList);

                var resaultStr = $"{InfoStore.SelectedServiceCod}";

                Android.Widget.Toast.MakeText(this,
                    resaultStr,
                    Android.Widget.ToastLength.Short).Show();

               SendFilterToServer(InfoStore.SelectedServiceCod);

                StartActivity(typeof(MainActivity));


               

        };

            Button noneServiceButton = FindViewById<Button>(Resource.Id.noneButton);
            noneServiceButton.Click += delegate
            {
                menuListView.ClearChoices();
                menuListView.RequestLayout();
            };

            Button allServiceButton = FindViewById<Button>(Resource.Id.allButton);
            allServiceButton.Click += delegate
            {
                for (int i = 0; i < InfoStore.Services.ToArray().Length; i++)
                {
                    menuListView.SetItemChecked(i, true);
                }
            };
        }


        public async void SendFilterToServer(long serviceCod)
        {

            //api / getAllStationsWithFilter
            //json: { "filters": 123456}
            try
            {
                string postStringFilterUrl = "http://193.124.57.9:2000/api/getAllStationsWithFilter";

                using (HttpClient client = new HttpClient())
                {
                    var currentFilterCod = new Requests.Filter()
                    {
                        filters = serviceCod
                    };

                    var json = JsonConvert.SerializeObject(currentFilterCod);
                    HttpResponseMessage response = await client.PostAsync(postStringFilterUrl, new StringContent(json, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        Android.Widget.Toast.MakeText(this,
                          "Please wait...",
                          Android.Widget.ToastLength.Long).Show();

                        var jsonFromServer = await response.Content.ReadAsStringAsync();
                        var infoAboutAzs = JsonConvert.DeserializeObject<List<MainInfoAzs>>(jsonFromServer);
                        InfoStore.InfoAzsWithFilter.Clear();
                        InfoStore.StationsOnMap.Clear();
                        InfoStore.InfoAzsWithFilter.AddRange(infoAboutAzs);
                        foreach (var tempStation in infoAboutAzs)
                        {
                            InfoStore.StationsOnMap.Add(new StationForMap(tempStation.coordinates, tempStation.operatorName, tempStation.codServices));
                        }


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

    }
}