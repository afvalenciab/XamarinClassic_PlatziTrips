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
    public class ListaViajeActivity : ListActivity
    {

        public ListaViajeActivity()
        {
            
        }

        List<Viaje> viajes;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            viajes = new List<Viaje>();
            viajes = DataBaseHelper.LeerViajes(MainActivity.ObtenerRutaBaseDatos());
            var arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, viajes);
            ListAdapter = arrayAdapter;            
        }

        protected override void OnRestart()
        {
            base.OnRestart();

            viajes = new List<Viaje>();
            viajes = DataBaseHelper.LeerViajes(MainActivity.ObtenerRutaBaseDatos());
            var arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, viajes);
            ListAdapter = arrayAdapter;
        }                
    }
}