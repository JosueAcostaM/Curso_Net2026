using API_Consumer;
using Libreria.Modelos;

Crud<Pais>.EndPoint = "https://localhost:7293/api/Paises";
Crud<Autor>.EndPoint = "https://localhost:7293/api/Autores";
Crud<Biblioteca>.EndPoint = "https://localhost:7293/api/Bibliotecas";
Crud<Cliente>.EndPoint = "https://localhost:7293/api/Clientes";
Crud<Libro>.EndPoint = "https://localhost:7293/api/Libros";
Crud<Prestamo>.EndPoint = "https://localhost:7293/api/Prestamos";






var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
