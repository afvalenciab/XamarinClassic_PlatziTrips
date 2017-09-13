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
    }
}
