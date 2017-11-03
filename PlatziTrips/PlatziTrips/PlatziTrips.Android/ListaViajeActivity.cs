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
        List<Viaje> viajes;

        public ListaViajeActivity()
        {
            
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListaViajes);
            
            viajesToolbar = FindViewById<Toolbar>(Resource.Id.ViajesToolbar);
            listaViajesListView = FindViewById<ListView>(Resource.Id.ListaViajesView);
            listaViajesListView.ItemClick += ListaViajesListView_ItemClick;

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

        private void ListaViajesListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var ciudad_seleccionada = viajes[e.Position];

            Intent intent = new Intent(this, typeof(DetallesViajeActivity));

            var bundle = new Bundle();
            bundle.PutString("nombre_ciudadSeleccionada", ciudad_seleccionada.Nombre);
            bundle.PutString("fechaIda_ciudadSeleccionada", ciudad_seleccionada.FechaInicio.ToString("MMM dd"));
            bundle.PutString("fechaRegreso_ciudadSeleccionada", ciudad_seleccionada.FechaRegreso.ToString("MMM dd"));
            bundle.PutInt("id_ciudadSeleccionada", ciudad_seleccionada.Id);

            intent.PutExtras(bundle);
            StartActivity(intent);
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