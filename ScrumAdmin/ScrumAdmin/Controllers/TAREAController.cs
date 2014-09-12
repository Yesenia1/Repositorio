using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumAdmin.Models;

namespace ScrumAdmin.Controllers
{   
    public class TAREAController : Controller
    {
		private readonly ITAREARepository tareaRepository;
        public Entities db = new Entities();

		// If you are using Dependency Injection, you can delete the following constructor
        public TAREAController() : this(new TAREARepository())
        {
        }

        public TAREAController(ITAREARepository tareaRepository)
        {
			this.tareaRepository = tareaRepository;
        }

        //
        // GET: /TAREA/

        public ViewResult Index()
        {
            return View(tareaRepository.All);
        }

        //
        // GET: /TAREA/Details/5

        public ViewResult Details(int id)
        {
            return View(tareaRepository.Find(id));
        }

        //
        // GET: /TAREA/Create

        public ActionResult Create()
        {

            return View();
        } 

        //
        // POST: /TAREA/Create

        [HttpPost]
        public ActionResult Create(TAREA tarea)
        {
            if (ModelState.IsValid) {
                tareaRepository.InsertOrUpdate(tarea);
                tareaRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /TAREA/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(tareaRepository.Find(id));
        }

        //
        // POST: /TAREA/Edit/5

        [HttpPost]
        public ActionResult Edit(TAREA tarea)
        {
            if (ModelState.IsValid) {
                tareaRepository.InsertOrUpdate(tarea);
                tareaRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /TAREA/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(tareaRepository.Find(id));
        }

        //
        // POST: /TAREA/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            tareaRepository.Delete(id);
            tareaRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                tareaRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

