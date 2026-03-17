using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Biblioteca
    {
        //Llave primaria
        [Key] public int Id { get; set; }

        public string Nombre_Biblioteca { get; set; }
        public string Direccion { get; set; }

    }
}
