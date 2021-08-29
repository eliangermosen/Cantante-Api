using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CantanteApi.Models
{
    public class Cantante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Alias { get; set; }
        public string Genero { get; set; }
        public string Nacionalidad { get; set; }
    }
}
