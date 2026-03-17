using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Libreria.Modelos;

namespace Libreria.API.Data
{
    public class LibreriaAPIContext : DbContext
    {
        public LibreriaAPIContext (DbContextOptions<LibreriaAPIContext> options)
            : base(options)
        {
        }

    }
}
