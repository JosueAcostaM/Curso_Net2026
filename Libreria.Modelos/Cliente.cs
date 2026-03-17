using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Cliente
    {
        [Key] public int Id { get; set; }

        public string Nombre_Cliente { get; set; }
        public string Apellido_Cliente { get; set; }
        public string Correo_Cliente { get; set; }

        public string Nombre_Usuario { get; set; }
        public string Contrasena_Cliente { get; set; }

        List<Prestamo>? Prestamos { get; set; } = new List<Prestamo>();
    }
}
