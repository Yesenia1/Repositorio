using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumAdmin.Models;

namespace ScrumAdmin.Controllers
{   
    public class PRIORIDADController : Controller
    {
		private readonly IPRIORIDADRepository prioridadRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public PRIORIDADController() : this(new PRIORIDADRepository())
        {
        }

        public PRIORIDADController(IPRIORIDADRepository prioridadRepository)
        {
			this.prioridadRepository = prioridadRepository;
        }

        //
        // GET: /PRIORIDAD/

        public ViewResult Index()
        {
            return View(prioridadRepository.AllIncluding(prioridad => prioridad.USER_STORY));
        }

        //
        // GET: /PRIORIDAD/Details/5

        public ViewResult Details(int id)
        {
            return View(prioridadRepository.Find(id));
        }

        //
        // GET: /PRIORIDAD/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /PRIORIDAD/Create

        [HttpPost]
        public ActionResult Create(PRIORIDAD prioridad)
        {
            if (ModelState.IsValid) {
                prioridadRepository.InsertOrUpdate(prioridad);
                prioridadRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /PRIORIDAD/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(prioridadRepository.Find(id));
        }

        //
        // POST: /PRIORIDAD/Edit/5

        [HttpPost]
        public ActionResult Edit(PRIORIDAD prioridad)
        {
            if (ModelState.IsValid) {
                prioridadRepository.InsertOrUpdate(prioridad);
                prioridadRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /PRIORIDAD/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(prioridadRepository.Find(id));
        }

        //
        // POST: /PRIORIDAD/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            prioridadRepository.Delete(id);
            prioridadRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                prioridadRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

