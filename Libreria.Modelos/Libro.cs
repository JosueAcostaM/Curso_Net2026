using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Libro
    {
        [Key] public int Id { get; set; }

        public string Titulo_Libro { get; set; }
        public int stock_Libro { get; set; }

        [ForeignKey("AutorId")]
        public int AutorId { get; set; }
        //Objeto de navegación
        public Autor? Autor { get; set; }

        [ForeignKey("BibliotecaId")]
        public int BibliotecaId { get; set; }
        //Objeto de navegación
        public Biblioteca? Biblioteca { get; set; }

        List<Prestamo>? Prestamos { get; set; } = new List<Prestamo>();
    }
}
