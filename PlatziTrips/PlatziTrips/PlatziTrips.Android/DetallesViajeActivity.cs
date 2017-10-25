using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PlatziTrips.Droid
{
    [Activity(Label = "DetallesViajeActivity")]
    public class DetallesViajeActivity : Activity
    {

        Toolbar detallesToolbar;
        TextView FechaTtextView, ciudadTextView;
        ListView detalleListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DetallesViaje);

            detallesToolbar = FindViewById<Toolbar>(Resource.Id.detallesToolbar);
            FechaTtextView = FindViewById<TextView>(Resource.Id.FechaTtextView);
            ciudadTextView = FindViewById<TextView>(Resource.Id.ciudadTextView);
            detalleListView = FindViewById<ListView>(Resource.Id.detalleListView);

            SetActionBar(detallesToolbar);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.agregar, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            if ("Agregar".Equals(item.TitleFormatted.ToString()))
            {
                Intent intent = new Intent(this, typeof(NuevoViajeActivity));
                StartActivity(intent);
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}