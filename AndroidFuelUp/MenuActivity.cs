using Android.App;
using Android.OS;
using Android.Widget;
using AndroidFuelUp.Core;
using AndroidFuelUp.Models;
using System.Collections.Generic;

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
    }
}