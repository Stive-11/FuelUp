using Android.App;
using Android.OS;
using Android.Widget;

namespace AndroidFuelUp
{
    [Activity(Label = "TestMenuActivity")]
    public class TestMenuActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TestMenu);

            string[] services = new string[]
            {
                "service 1", "service 2", "service 3",
                "service 4", "service 5", "service 6",
                "service 7", "service 8", "service 9",
                "service 10", "service 1", "service 2",
                "service 3", "service 4", "service 5",
                "service 6", "service 7", "service 8",
                "service 9", "service 10"
            };

            var testListView = FindViewById<ListView>(Resource.Id.listViewTestMenu);
            testListView.Adapter = new ArrayAdapter<string>(this,
                Android.Resource.Layout.SimpleListItemMultipleChoice, services);

            testListView.ChoiceMode = ChoiceMode.Multiple;

            testListView.SetItemChecked(1, true);

            //  testListView.SetOnClickListener(new AdapterView.IOnItemClickListener);

            testListView.ItemClick += (object sender,
                AdapterView.ItemClickEventArgs e) =>
            {
                Android.Widget.Toast.MakeText(this,
                    "The row #" + e.Position.ToString() + "is tappad",
                    Android.Widget.ToastLength.Short).Show();

                //var sparseArray = FindViewById<ListView>(Resource.Id.listViewTestMenu).CheckedItemPositions;
                //for (var i = 0; i < sparseArray.Size(); i++)
                //{
                //    Android.Widget.Toast.MakeText(this,
                //    "The row #" + sparseArray.KeyAt(i).ToString() + "is tappad ->" + sparseArray.ValueAt(i),
                //    Android.Widget.ToastLength.Short).Show();
                //    // Console.Write(sparseArray.KeyAt(i) + "=" + sparseArray.ValueAt(i) + ",");
                //}
            };
        }
    }
}