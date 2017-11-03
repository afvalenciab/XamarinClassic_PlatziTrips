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
    [Activity(Label = "VenuesActivity")]
    public class VenuesActivity : Activity
    {
        EditText filtroEditText;
        Spinner categoriaSpinner;
        ListView venuesListView;
        Toolbar nuevoLugarToolbar;

        List<Category> categorias;
        List<Venue> listVenues;

        string nombreCiudadSelecccionad;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.NuevoLugar);

            filtroEditText = FindViewById<EditText>(Resource.Id.filtroEditText);
            categoriaSpinner = FindViewById<Spinner>(Resource.Id.CategoriaSpinner);
            venuesListView = FindViewById<ListView>(Resource.Id.venuesListView);
            nuevoLugarToolbar = FindViewById<Toolbar>(Resource.Id.nuevoLuegarToolbar);

            FoursquareHelper helper = new FoursquareHelper();
            categorias = await helper.ObtenerCategorias();

            var spinnerAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, categorias);
            categoriaSpinner.Adapter = spinnerAdapter;

            categoriaSpinner.ItemSelected += CategoriaSpinner_ItemSelected;
            nombreCiudadSelecccionad = Intent.Extras.GetString("nombre_ciudadSeleccionada");

            filtroEditText.TextChanged += FiltroEditText_TextChanged;
        }
        
        private async void CategoriaSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var categoriaSeleccionada = categorias[e.Position];

            FoursquareHelper helper = new FoursquareHelper();
            listVenues = await helper.ObtenerLugares(nombreCiudadSelecccionad, categoriaSeleccionada.id);

            var venuesAdapter = new ArrayAdapter(this,Android.Resource.Layout.SimpleListItem1,listVenues);
            venuesListView.Adapter = venuesAdapter;
        }

        private void FiltroEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            var listaFiltrada = listVenues.Where(v => v.name.ToLower().Contains(filtroEditText.Text.ToLower())).ToList();

            var venusAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, listaFiltrada);
            venuesListView.Adapter = venusAdapter;
        }
    }
}