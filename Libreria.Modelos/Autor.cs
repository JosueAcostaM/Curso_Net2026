using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Autor
    {
        [Key] public int Id { get; set; }

        public string Nombres_Autor { get; set; }
        public string Apellidos_Autor { get; set; }

        public DateTime Fecha_Nacimiento { get; set; }

        //Llave foranea
        [ForeignKey("PaisId")]
        public int PaisId { get; set; }
        public Pais? Pais { get; set; }


        List<Libro>? Libros { get; set; } = new List<Libro>();


    }
}
