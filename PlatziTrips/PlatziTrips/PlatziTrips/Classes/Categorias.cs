using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatziTrips.Classes
{
    public class Categorias
    {
        public Response response { get; set; }
    }

    public class Response
    {
        public List<Category> categories { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }        
        public string shortName { get; set; }                
    }
}
