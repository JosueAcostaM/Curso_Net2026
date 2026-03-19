using API_Consumer;
using Libreria.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.MVC.Controllers
{
    public class PaisesController : Controller
    {
        // GET: PaisesController
        public ActionResult Index()
        {
            var paises= Crud<Pais>.GetAll();
            return View(paises);
        }

        // GET: PaisesController/Details/5
        public ActionResult Details(int id)
        {
            var paises = Crud<Pais>.GetById(id);

                if (paises == null)
                {
                    return NotFound();
            }

            return View(paises);
        }

        // GET: PaisesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaisesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pais pais)
        {
            try
            {
                Crud<Pais>.Create(pais);
                return RedirectToAction(nameof(Index));
            }
            catch ( Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(pais);
            }
        }

        // GET: PaisesController/Edit/5
        public ActionResult Edit(int id)
        {
            var pais = Crud<Pais>.GetById(id);

            if (pais == null) {
                return NotFound();
            }
            return View(pais);
        }

        // POST: PaisesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pais pais)
        {
            try
            {
                Crud<Pais>.Update(id, pais);
                return RedirectToAction(nameof(Index));
            }
            catch ( Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(pais);
            }
        }

        // GET: PaisesController/Delete/5
        public ActionResult Delete(int id)
        {
            var pais = Crud<Pais>.GetById(id);
            if (pais == null)
            {
                return NotFound();
            }
            return View(pais);
        }

        // POST: PaisesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pais pais)
        {
            try
            {
                Crud<Pais>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch ( Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(pais);
            }
        }
    }
}
