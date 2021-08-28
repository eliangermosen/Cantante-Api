using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RitmoApi.Models
{
    public class Ritmo
    {
        [Key]
        public int ID { get; set; }

        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public string ALIAS { get; set; }
        public string GENERO { get; set; }
        public string NACIONALIDAD { get; set; }
    }
}
