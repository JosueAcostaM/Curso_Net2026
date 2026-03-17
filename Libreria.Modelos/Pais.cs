using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Pais
    {
        [Key] public int Id { get; set; }

        public string Nombre_Pais { get; set; }

    }
}
