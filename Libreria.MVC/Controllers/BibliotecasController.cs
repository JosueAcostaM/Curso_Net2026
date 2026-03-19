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
            return View();
        }

        // GET: BibliotecasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BibliotecasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BibliotecasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BibliotecasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BibliotecasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BibliotecasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
