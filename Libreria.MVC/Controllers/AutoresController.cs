using API_Consumer;
using Libreria.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.MVC.Controllers
{
    public class AutoresController : Controller
    {
        // GET: AutoresController
        public ActionResult Index()
        {
            var autores= Crud<Autor>.GetAll();
            return View(autores);
        }

        // GET: AutoresController/Details/5
        public ActionResult Details(int id)
        {
            var autor = Crud<Autor>.GetById(id);

            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        private List<SelectListItem> GetPaises()
        {
            var paises = Crud<Pais>.GetAll();
            return paises.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Nombre_Pais 
            }).ToList();
        }

        // GET: AutoresController/Create
        public ActionResult Create()
        {
            ViewBag.Paises = GetPaises();
            return View();
        }

        // POST: AutoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Autor autor)
        {
            try
            {
                Crud<Autor>.Create(autor);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(autor);
            }
        }

        // GET: AutoresController/Edit/5
        public ActionResult Edit(int id)
        {
            var autor = Crud<Autor>.GetById(id);
            ViewBag.Paises = GetPaises();

            if(autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: AutoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Autor autor)
        {
            try
            {
                Crud<Autor>.Update(id, autor);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(autor);
            }
        }

        // GET: AutoresController/Delete/5
        public ActionResult Delete(int id)
        {
            var autor = Crud<Autor>.GetById(id);

            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        // POST: AutoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Autor autor)
        {
            try
            {
                Crud<Autor>.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(autor);
            }
        }
    }
}
