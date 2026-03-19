using API_Consumer;
using Libreria.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.MVC.Controllers
{
    public class LibrosController : Controller
    {
        // GET: LibrosController
        public ActionResult Index()
        {
            var libros= Crud<Libro>.GetAll();
            return View(libros);
        }

        // GET: LibrosController/Details/5
        public ActionResult Details(int id)
        {
            var libro = Crud<Libro>.GetById(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        private List<SelectListItem> GetAutores()
        {
            var autores = Crud<Autor>.GetAll();
            return autores.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = $"{p.Nombres_Autor} {p.Apellidos_Autor}"
            }).ToList();
        }

        private List<SelectListItem> GetBibliotecas()
        {
            var bibliotecas = Crud<Biblioteca>.GetAll();
            return bibliotecas.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Nombre_Biblioteca
            }).ToList();
        }

        // GET: LibrosController/Create
        public ActionResult Create()
        {
            
            ViewBag.Autores = GetAutores();
            ViewBag.Bibliotecas = GetBibliotecas();
            return View();
        }

        // POST: LibrosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Libro libro)
        {
            try
            {
                Crud<Libro>.Create(libro);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", ex.Message);
                    return View();
            }
        }

        // GET: LibrosController/Edit/5
        public ActionResult Edit(int id)
        {
            var libro = Crud<Libro>.GetById(id);

            if (libro == null)
            {
                return NotFound();
            }

            ViewBag.Autores = GetAutores();
            ViewBag.Bibliotecas = GetBibliotecas();

            return View(libro);
        }

        // POST: LibrosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Libro libro)
        {
            try
            {
                Crud<Libro>.Update(id,libro);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: LibrosController/Delete/5
        public ActionResult Delete(int id)
        {
            var libro = Crud<Libro>.GetById(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: LibrosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Libro libro)
        {
            try
            {
                Crud<Libro>.Delete(id);
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
