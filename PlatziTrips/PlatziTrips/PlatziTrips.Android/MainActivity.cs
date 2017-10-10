using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PlatziTrips.Classes;
using System.IO;

namespace PlatziTrips.Droid
{
	[Activity (Label = "PlatziTrips.Android", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        EditText userEditText, passwordEditText;
        Button loginButton;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);            

            userEditText = FindViewById<EditText>(Resource.Id.userEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            loginButton = FindViewById<Button>(Resource.Id.loginButton);

            loginButton.Click += LoginButton_Click;
		}

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (InicioSesion.IniciarSesion(userEditText.Text, passwordEditText.Text))
            {
                Intent intent = new Intent(this, typeof(NuevoViajeActivity));
                StartActivity(intent);
            }
        }

        public static string ObtenerRutaBaseDatos()
        {
            string nombreArchivoBD = "viaje_db.sqlite";
            string ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            return Path.Combine(ruta, nombreArchivoBD);            
        }


    }
}


