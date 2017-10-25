using PlatziTrips.Classes.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlatziTrips.Classes
{
    class FoursquareHelper
    {
        public async Task<List<Category>> ObtenerCategorias()
        {
            List<Category> listCategorias = new List<Category>();
            string url = Constantes.ObtenerUrlCategorias();

            using (HttpClient client = new HttpClient() )
            {
                var foursquareCategory = await client.GetStringAsync(url);
                Categorias categorias = JsonConvert.DeserializeObject<Categorias>(foursquareCategory);

                listCategorias = categorias.response.categories;
            }
            
            return listCategorias;
        }

        public async Task<List<Venue>> ObtenerLugares(string ciudad, string idCategoria)
        {
            List<Venue> listLugares = new List<Venue>();
            string url = Constantes.ObtenerURLLugares(ciudad, idCategoria);

            using (HttpClient client = new HttpClient())
            {
                var foursquareLugares = await client.GetStringAsync(url);
                Lugares lugares = JsonConvert.DeserializeObject<Lugares>(foursquareLugares);

                listLugares = lugares.response.venues;
            }

            return listLugares;
        }
    }
}
