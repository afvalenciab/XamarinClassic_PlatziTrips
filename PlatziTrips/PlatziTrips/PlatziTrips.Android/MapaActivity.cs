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
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace PlatziTrips.Droid
{
    [Activity(Label = "MapaActivity")]
    public class MapaActivity : Activity, IOnMapReadyCallback
    {
        double[] arrayLatitudes, arrayLongitudes;

        public void OnMapReady(GoogleMap googleMap)
        {

            for (int i = 0; i < arrayLongitudes.Length; i++)
            {
                MarkerOptions option = new MarkerOptions();
                option.SetPosition(new LatLng(arrayLatitudes[i],arrayLongitudes[i]));

                googleMap.AddMarker(option);
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.mapas);

            arrayLatitudes = Intent.GetDoubleArrayExtra("ArrayLatitudes");
            arrayLongitudes = Intent.GetDoubleArrayExtra("ArrayLongitudes");

            MapFragment mapFragment = (MapFragment) FragmentManager.FindFragmentById(Resource.Id.mapaFragment);
            mapFragment.GetMapAsync(this);
        }
    }
}