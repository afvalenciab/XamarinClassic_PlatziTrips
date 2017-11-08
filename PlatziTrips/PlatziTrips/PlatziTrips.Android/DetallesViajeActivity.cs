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
    [Activity(Label = "DetallesViajeActivity")]
    public class DetallesViajeActivity : Activity
    {
        Toolbar detallesToolbar;
        TextView FechaTtextView, ciudadTextView;
        ListView detalleListView;
        string nombreCiudadSeleccionada, fechaIda, fechaRegreso;
        int idCiudadSeleccionada;
        List<LugarDeInteres> listLugaresDeInteres;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DetallesViaje);

            detallesToolbar = FindViewById<Toolbar>(Resource.Id.detallesToolbar);
            FechaTtextView = FindViewById<TextView>(Resource.Id.FechaTtextView);
            ciudadTextView = FindViewById<TextView>(Resource.Id.ciudadTextView);
            detalleListView = FindViewById<ListView>(Resource.Id.detalleListView);

            SetActionBar(detallesToolbar);

            nombreCiudadSeleccionada = Intent.Extras.GetString("nombre_ciudadSeleccionada");
            fechaIda = Intent.Extras.GetString("fechaIda_ciudadSeleccionada");
            fechaRegreso = Intent.Extras.GetString("fechaRegreso_ciudadSeleccionada");
            idCiudadSeleccionada = Intent.Extras.GetInt("id_ciudadSeleccionada");

            ciudadTextView.Text = nombreCiudadSeleccionada;
            FechaTtextView.Text = $"{fechaIda} - {fechaRegreso}";

            listLugaresDeInteres = new List<LugarDeInteres>();
            listLugaresDeInteres = DataBaseHelper.LeerLugaresDeInteres(idCiudadSeleccionada, MainActivity.ObtenerRutaBaseDatos());
            var arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, listLugaresDeInteres);
            detalleListView.Adapter = arrayAdapter;

            ciudadTextView.Click += CiudadTextView_Click;
        }        

        protected override void OnRestart()
        {
            base.OnRestart();

            listLugaresDeInteres = DataBaseHelper.LeerLugaresDeInteres(idCiudadSeleccionada, MainActivity.ObtenerRutaBaseDatos());
            var arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, listLugaresDeInteres);
            detalleListView.Adapter = arrayAdapter;
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
                Intent intent = new Intent(this, typeof(VenuesActivity));
                var bundle = new Bundle();
                bundle.PutString("nombre_ciudadSeleccionada",nombreCiudadSeleccionada);
                bundle.PutInt("id_ciudadSeleccionada", idCiudadSeleccionada);

                intent.PutExtras(bundle);
                StartActivity(intent);
            }

            return base.OnOptionsItemSelected(item);
        }

        private void CiudadTextView_Click(object sender, EventArgs e)
        {
            double[] arrayLongitudes = new double[listLugaresDeInteres.Count];
            double[] arrayLatitudes = new double[listLugaresDeInteres.Count];

            int contador = 0;
            foreach (var lugar in listLugaresDeInteres)
            {
                arrayLatitudes[contador] = lugar.Latitud;
                arrayLongitudes[contador] = lugar.Longitud;
                contador++;
            }

            Intent intent = new Intent(this, typeof(MapaActivity));
            Bundle bundle = new Bundle();

            bundle.PutDoubleArray("ArrayLatitudes", arrayLatitudes);
            bundle.PutDoubleArray("ArrayLongitudes", arrayLongitudes);

            intent.PutExtras(bundle);
            StartActivity(intent);
        }
    }
}