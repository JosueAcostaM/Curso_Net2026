using API_Consumer;
using Libreria.Modelos;
using Libreria.Servicios.Interfaces;
using Libreria.Servicios;

Crud<Pais>.EndPoint = "https://localhost:7293/api/Paises";
Crud<Autor>.EndPoint = "https://localhost:7293/api/Autores";
Crud<Biblioteca>.EndPoint = "https://localhost:7293/api/Bibliotecas";
Crud<Cliente>.EndPoint = "https://localhost:7293/api/Clientes";
Crud<Libro>.EndPoint = "https://localhost:7293/api/Libros";
Crud<Prestamo>.EndPoint = "https://localhost:7293/api/Prestamos";


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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
