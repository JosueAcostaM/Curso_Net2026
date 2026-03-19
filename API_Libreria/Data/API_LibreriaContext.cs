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

        public DbSet<Libreria.Modelos.Autor> Autores { get; set; } = default!;
        public DbSet<Libreria.Modelos.Pais> Paises { get; set; } = default!;
        public DbSet<Libreria.Modelos.Biblioteca> Bibliotecas { get; set; } = default!;
        public DbSet<Libreria.Modelos.Cliente> Clientes { get; set; } = default!;
        public DbSet<Libreria.Modelos.Libro> Libros { get; set; } = default!;
        public DbSet<Libreria.Modelos.Prestamo> Prestamos { get; set; } = default!;
    }
}
