using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using API_Consumer;
using Libreria.Modelos;
using Libreria.Servicios.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;

namespace Libreria.Servicios
{
    public class AuthService : Interfaces.IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> Login(string email, string password)
        {
            var usuarios = Crud<Cliente>.GetAll();

            foreach (var usuario in usuarios)
            {
                if (usuario.Correo_Cliente == email)
                {
                    //BCrypt compara el texto plano con el Hash de la base de datos
                    if (BCrypt.Net.BCrypt.Verify(password, usuario.Contrasena_Cliente))
                    {
                        var datosUsuario = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.Nombre_Cliente),
                        new Claim(ClaimTypes.Email, usuario.Correo_Cliente),
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    };

                        var credencialDigital = new ClaimsIdentity(datosUsuario, "Cookies");
                        var usuarioAutenticado = new ClaimsPrincipal(credencialDigital);

                        await _httpContextAccessor.HttpContext.SignInAsync("Cookies", usuarioAutenticado);
                        return true;
                    }
                }
            }
            return false;
        }



        public async Task<bool> Register(
            string nombre,
            string apellido,
            string email,
            string nombreUsuario,
            string password)
        {
            //Verificamos duplicados con endpoints específicos
            var usuarioExistente = Crud<Cliente>.GetAll()
                 .FirstOrDefault(u => u.Correo_Cliente == email);

            if (usuarioExistente != null)
            {
                Console.WriteLine("Error: El correo ya está registrado.");
                return false;
            }

            try
            {
                //CREACIÓN DEL OBJETO USUARIO CON HASH SEGURIDAD
               var nuevoUsuario = new Cliente
               {
                   Id = 0,
                   Nombre_Cliente = nombre,
                   Apellido_Cliente = apellido,
                   Correo_Cliente = email,
                   Nombre_Usuario = nombreUsuario,
                   Contrasena_Cliente = password
               };

                Crud<Cliente>.Create(nuevoUsuario);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar usuario: {ex.Message}");
                return false;
            }
        }
    }
}
