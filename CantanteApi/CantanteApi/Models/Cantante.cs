using System;
using System.Collections.Generic;

#nullable disable

namespace CantanteApi.Models
{
    public partial class Cantante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Alias { get; set; }
        public string Genero { get; set; }
        public string Nacionalidad { get; set; }
    }
}
