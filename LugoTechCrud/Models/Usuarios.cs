using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LugoTechCrud.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreUsuario { get; set; }
        public string Contra { get; set; }
        public string Genero { get; set; }
        public string Nacionalidad { get; set; }
        public int TipoUsuario { get; set; }
        public Boolean Estado { get; set; }
    }
}
