using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Libreria.Modelos;

namespace API_Libreria.Data
{
    public class API_LibreriaContext : DbContext
    {
        public API_LibreriaContext (DbContextOptions<API_LibreriaContext> options)
            : base(options)
        {
        }

        public DbSet<Libreria.Modelos.Autor> Autor { get; set; } = default!;
        public DbSet<Libreria.Modelos.Pais> Pais { get; set; } = default!;
        public DbSet<Libreria.Modelos.Biblioteca> Biblioteca { get; set; } = default!;
        public DbSet<Libreria.Modelos.Cliente> Cliente { get; set; } = default!;
        public DbSet<Libreria.Modelos.Libro> Libro { get; set; } = default!;
        public DbSet<Libreria.Modelos.Prestamo> Prestamo { get; set; } = default!;
    }
}
