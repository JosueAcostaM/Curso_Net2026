using Libreria.Modelos;
using API_Consumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.MVC.Controllers
{
    public class PrestamosController : Controller
    {
        // GET: PrestamosController
        public ActionResult Index()
        {
            var prestamos= Crud<Prestamo>.GetAll();
            return View(prestamos);
        }

        // GET: PrestamosController/Details/5
        public ActionResult Details(int id)
        {
            var prestamo = Crud<Prestamo>.GetById(id);

            if (prestamo == null)
            {
                return NotFound();
            }

            return View(prestamo);

        }

        private List<SelectListItem> GetLibros()
        {
            var libros = Crud<Libro>.GetAll();
            return libros.Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Titulo_Libro
            }).ToList();
        }

        private List<SelectListItem> GetClientes()
        {
            var clientes = Crud<Cliente>.GetAll();
            return clientes.Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = $"{u.Nombre_Cliente} {u.Apellido_Cliente}"
            }).ToList();
        }


        // GET: PrestamosController/Create
        public ActionResult Create()
        {
            ViewBag.Libros = GetLibros();
            ViewBag.Clientes = GetClientes();
            return View();
        }

        // POST: PrestamosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Prestamo prestamo)
        {
            try
            {
                Crud<Prestamo>.Create(prestamo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", ex.Message);
                    return View();
            }
        }

        // GET: PrestamosController/Edit/5
        public ActionResult Edit(int id)
        {
            var prestamo = Crud<Prestamo>.GetById(id);

            if (prestamo == null)
            {
                return NotFound();
            }

            ViewBag.Libros = GetLibros();
            ViewBag.Clientes = GetClientes();

            return View(prestamo);
        }

        // POST: PrestamosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Prestamo prestamo)
        {
            try
            {
                Crud<Prestamo>.Update(id, prestamo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: PrestamosController/Delete/5
        public ActionResult Delete(int id)
        {
            var prestamo = Crud<Prestamo>.GetById(id);

            if (prestamo == null)
            {
                return NotFound();
            }

            return View (prestamo);
        }

        // POST: PrestamosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Prestamo prestamo)
        {
            try
            {
                Crud<Prestamo>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}
