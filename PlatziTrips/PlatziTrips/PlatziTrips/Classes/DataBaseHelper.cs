using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatziTrips.Classes
{
    public class DataBaseHelper
    {
        public DataBaseHelper() { }

        public static bool Insertar<T>(ref T item, string ruta_db)
        {
            bool estado_insercion=false;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(ruta_db))
            {
                conn.CreateTable<T>();

                if (conn.Insert(item) > 0)
                    estado_insercion = true;
            }

            return estado_insercion;
        }

        public static List<Viaje> LeerViajes(string ruta_db)
        {
            List<Viaje> listViaje = new List<Viaje>();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(ruta_db))
            {
                listViaje = conn.Table<Viaje>().ToList();
            }

            return listViaje;
        }
    }
}
