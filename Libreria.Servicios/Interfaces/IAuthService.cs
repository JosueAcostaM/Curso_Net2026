using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Servicios.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Login(string username, string password);

        Task<bool> Register(
            string nombre,
            string apellido,
            string email,
            string nombreUsuario,
            string password
        );
    }
}
