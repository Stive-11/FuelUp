using Android.App;
using Android.OS;
using Android.Widget;
using AndroidFuelUp.Core;
using AndroidFuelUp.Models;
using System.Collections.Generic;

namespace AndroidFuelUp
{
    [Activity(Label = "TestMenuActivity")]
    public class TestMenuActivity : Activity
    {
        private List<string> resault = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ServicesMenu);

            var testListView = FindViewById<ListView>(Resource.Id.listViewTestMenu);
            testListView.Adapter = new ArrayAdapter<string>(this,
                Android.Resource.Layout.SimpleListItemMultipleChoice, InfoStore.Services.ToArray());

            testListView.ChoiceMode = ChoiceMode.Multiple;

            //testListView.SetItemChecked(1, true);

            //  testListView.SetOnClickListener(new AdapterView.IOnItemClickListener);

            //testListView.ItemClick += (object sender,
            //    AdapterView.ItemClickEventArgs e) =>
            //{
            //    Android.Widget.Toast.MakeText(this,
            //        "The row #" + e.Position.ToString() + "is tappad",
            //        Android.Widget.ToastLength.Short).Show();
            //};

            Button theDoneButton = FindViewById<Button>(Resource.Id.doneButton);
            theDoneButton.Click += delegate
            {
                var checkedList = new List<string>();
                var arrayServices = InfoStore.Services.ToArray();
                var sparseArray = FindViewById<ListView>(Resource.Id.listViewTestMenu).CheckedItemPositions;
                //var size = sparseArray.Size();
                for (var i = 0; i < sparseArray.Size(); i++)
                {
                    var key = sparseArray.Get(sparseArray.KeyAt(i));
                    if (key)
                        checkedList.Add(arrayServices[sparseArray.KeyAt(i)]);                    
                }

               var resaultStr = $"{ServiceDecoder.GetServicesCod(checkedList)}";

                Android.Widget.Toast.MakeText(this,
                    resaultStr,
                    Android.Widget.ToastLength.Short).Show();
            };
        }
    }
}