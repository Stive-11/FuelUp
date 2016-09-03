using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace AndroidFuelUp
{
    [Activity(Label = "MenuActivity")]
    public class MenuActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainMenu);

            string[] services = new string[]
            {
                "service 1",
                "service 2",
                "service 3",
                "service 4",
                "service 5",
                "service 6",
                "service 7",
                "service 8",
                "service 9",
                "service 10",
                 "service 1",
                "service 2",
                "service 3",
                "service 4",
                "service 5",
                "service 6",
                "service 7",
                "service 8",
                "service 9",
                "service 10"
            };

            ListView.Adapter = new ArrayAdapter<string>(
                this,
                Android.Resource.Layout.SimpleListItem1, services

                );
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            Android.Widget.Toast.MakeText(this,
                "The row #" + position.ToString() + "is tappad",
                Android.Widget.ToastLength.Short).Show();
        }
    }
}