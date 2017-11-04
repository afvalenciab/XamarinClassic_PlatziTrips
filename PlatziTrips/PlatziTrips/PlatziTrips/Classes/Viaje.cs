using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatziTrips.Classes
{
    public class Viaje
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(150)]
        public string Nombre { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaRegreso { get; set; }

        public override string ToString()
        {
            return $"{Nombre} ({FechaInicio} - {FechaRegreso})";
        }
    }

    public class LugarDeInteres
    {
        public LugarDeInteres()
        {

        }

        public LugarDeInteres(Venue venue, int idViaje)
        {
            IdViaje = idViaje;
            Nombre = venue.name;
            Latitud = (float) venue.location.lat;
            Longitud = (float) venue.location.lng;
            Categoria = venue.categories.First().name;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Nombre { get; set; }
        public float Latitud { get; set; }
        public float Longitud { get; set; }
        public int IdViaje { get; set; }
        public string Categoria { get; set; }

        public override string ToString()
        {
            return $"{Nombre}";
        }

    }
}
