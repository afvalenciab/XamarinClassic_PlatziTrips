using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatziTrips.Classes.Helper
{
    public class Constantes
    {
        public const string CLIENT_ID = "M3NUDF5KAYHN5ZAFEPPNGID0TALSD1U4B1KFNXYOFJYQA22E";
        public const string CLIENT_SECRET = "MQSMMNIHXPQ2MXA2JDUBAAOOBCCENKNPUWAEYF4QB2IWQO0Q";

        public static string ObtenerUrlCategorias()
        {
            return $"https://api.foursquare.com/v2/venues/categories?client_id={CLIENT_ID}&client_secret={CLIENT_SECRET}&v={DateTime.Now.ToString("yyyyMMdd")}";
        }

        public static string ObtenerURLLugares(string ciudad, string idCategoria)
        {
            return $"https://api.foursquare.com/v2/venues/search?near={ciudad}&categoryId={idCategoria}&client_id={CLIENT_ID}&client_secret={CLIENT_SECRET}&v={DateTime.Now.ToString("yyyyMMdd")}";
        }

    }
}
