using API_Consumer;
using Libreria.Modelos;
using Libreria.Servicios.Interfaces;
using Libreria.Servicios;

Crud<Pais>.EndPoint = "https://curso-net2026.onrender.com/api/Paises";
Crud<Autor>.EndPoint = "https://curso-net2026.onrender.com/api/Autores";
Crud<Biblioteca>.EndPoint = "https://curso-net2026.onrender.com/api/Bibliotecas";
Crud<Cliente>.EndPoint = "https://curso-net2026.onrender.com/api/Clientes";
Crud<Libro>.EndPoint = "https://curso-net2026.onrender.com/api/Libros";
Crud<Prestamo>.EndPoint = "https://curso-net2026.onrender.com/api/Prestamos";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddAuthentication("Cookies") //cokies
                .AddCookie("Cookies", options =>
                {
                    options.LoginPath = "/Account/Index"; // Ruta de inicio de sesión


                });
builder.Services.AddHttpContextAccessor();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();
