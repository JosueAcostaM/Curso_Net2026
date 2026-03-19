using API_Consumer;
using Libreria.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.MVC.Controllers
{
    public class BibliotecasController : Controller
    {
        // GET: BibliotecasController
        public ActionResult Index()
        {
            var bibliotecas= Crud<Biblioteca>.GetAll();
            return View(bibliotecas);
        }

        // GET: BibliotecasController/Details/5
        public ActionResult Details(int id)
        {
            var biblioteca = Crud<Biblioteca>.GetById(id);
            if (biblioteca == null)
            {
                return NotFound();
            }
            return View(biblioteca);
        }

        // GET: BibliotecasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BibliotecasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Biblioteca biblioteca)
        {
            try
            {
                Crud<Biblioteca>.Create(biblioteca);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(biblioteca);
            }
        }

        // GET: BibliotecasController/Edit/5
        public ActionResult Edit(int id)
        {
            var biblioteca = Crud<Biblioteca>.GetById(id);

            if (biblioteca == null)
            {
                return NotFound();
            }

            return View(biblioteca);
        }

        // POST: BibliotecasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Biblioteca biblioteca)
        {
            try
            {
                Crud<Biblioteca>.Update(id, biblioteca);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: BibliotecasController/Delete/5
        public ActionResult Delete(int id)
        {
            var biblioteca = Crud<Biblioteca>.GetById(id);

            if (biblioteca == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: BibliotecasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Biblioteca biblioteca)
        {
            try
            {
                Crud<Biblioteca>.Delete(id);
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
