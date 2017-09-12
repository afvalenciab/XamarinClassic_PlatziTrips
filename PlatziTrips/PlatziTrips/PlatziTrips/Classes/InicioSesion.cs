using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatziTrips.Classes
{
    public class InicioSesion
    {
        public InicioSesion()
        { }

        public static bool IniciarSesion(string user, string password)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
                return true;
            else
                return false;            
        }

    }
}
