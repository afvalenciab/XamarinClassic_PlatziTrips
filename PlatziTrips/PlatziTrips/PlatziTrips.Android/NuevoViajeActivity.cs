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
using System.IO;
using PlatziTrips.Classes;

namespace PlatziTrips.Droid
{
    [Activity(Label = "NuevoViajeActivity")]
    public class NuevoViajeActivity : Activity
    {
        EditText lugarViajeEdtiText;
        DatePicker fechaIdaDatePicker, fechaRegresoDatePicker;
        Button guardarViajeButton, verViajesButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.NuevoViaje);

            lugarViajeEdtiText = FindViewById<EditText>(Resource.Id.lugarViajeEdtiText);
            fechaIdaDatePicker = FindViewById<DatePicker>(Resource.Id.fechaIdaDatePicker);
            fechaRegresoDatePicker = FindViewById<DatePicker>(Resource.Id.fechaRegresoDatePicker);
            guardarViajeButton = FindViewById<Button>(Resource.Id.guardarViajeButton);
            verViajesButton = FindViewById<Button>(Resource.Id.verViajesButton);

            guardarViajeButton.Click += GuardarViajeButton_Click;
            verViajesButton.Click += VerViajesButton_Click;
        }

        private void VerViajesButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ListaViajeActivity));
            StartActivity(intent);
        }

        private void GuardarViajeButton_Click(object sender, EventArgs e)
        {
            var nuevoViaje = new Viaje()
            {
                Nombre = lugarViajeEdtiText.Text,
                FechaInicio = fechaIdaDatePicker.DateTime,
                FechaRegreso = fechaRegresoDatePicker.DateTime
            };

            if (DataBaseHelper.Insertar(ref nuevoViaje, MainActivity.ObtenerRutaBaseDatos()))
                Toast.MakeText(this,"Insertado Correctamente", ToastLength.Short).Show();
            else
                Toast.MakeText(this, "Error al guardar", ToastLength.Short).Show();
        }        
    }
}