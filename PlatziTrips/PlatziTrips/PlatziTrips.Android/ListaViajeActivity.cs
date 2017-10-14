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
using PlatziTrips.Classes;

namespace PlatziTrips.Droid
{
    [Activity(Label = "ListaViajeActivity")]
    public class ListaViajeActivity : Activity
    {

        Toolbar viajesToolbar;
        ListView listaViajesListView;


        public ListaViajeActivity()
        {
            
        }

        List<Viaje> viajes;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListaViajes);
            
            viajesToolbar = FindViewById<Toolbar>(Resource.Id.ViajesToolbar);
            listaViajesListView = FindViewById<ListView>(Resource.Id.ListaViajesView);

            SetActionBar(viajesToolbar);
            ActionBar.Title = "Mis Viajes";

            viajes = new List<Viaje>();
            viajes = DataBaseHelper.LeerViajes(MainActivity.ObtenerRutaBaseDatos());
            var arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, viajes);
            listaViajesListView.Adapter = arrayAdapter;            
        }

        protected override void OnRestart()
        {
            base.OnRestart();

            viajes = new List<Viaje>();
            viajes = DataBaseHelper.LeerViajes(MainActivity.ObtenerRutaBaseDatos());
            var arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, viajes);
            listaViajesListView.Adapter = arrayAdapter;            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.agregar,menu);

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