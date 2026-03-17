using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Prestamo
    {
        [Key] public int Id { get; set; }
        public string Descripcion_Prestamo { get; set; }

        public DateTime Fecha_Prestamo { get; set; }
        public DateTime Fecha_Devolucion { get; set; }

        public bool Estado_Prestamo { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [ForeignKey("LibroId")]
        public int LibroId { get; set; }
        public Libro? Libro { get; set; }

    }
}
