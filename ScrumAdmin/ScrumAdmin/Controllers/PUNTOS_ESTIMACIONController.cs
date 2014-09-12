using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumAdmin.Models;

namespace ScrumAdmin.Controllers
{   
    public class PUNTOS_ESTIMACIONController : Controller
    {
		private readonly IPUNTOS_ESTIMACIONRepository puntos_estimacionRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public PUNTOS_ESTIMACIONController() : this(new PUNTOS_ESTIMACIONRepository())
        {
        }

        public PUNTOS_ESTIMACIONController(IPUNTOS_ESTIMACIONRepository puntos_estimacionRepository)
        {
			this.puntos_estimacionRepository = puntos_estimacionRepository;
        }

        //
        // GET: /PUNTOS_ESTIMACION/

        public ViewResult Index()
        {
            return View(puntos_estimacionRepository.AllIncluding(puntos_estimacion => puntos_estimacion.USER_STORY));
        }

        //
        // GET: /PUNTOS_ESTIMACION/Details/5

        public ViewResult Details(int id)
        {
            return View(puntos_estimacionRepository.Find(id));
        }

        //
        // GET: /PUNTOS_ESTIMACION/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /PUNTOS_ESTIMACION/Create

        [HttpPost]
        public ActionResult Create(PUNTOS_ESTIMACION puntos_estimacion)
        {
            if (ModelState.IsValid) {
                puntos_estimacionRepository.InsertOrUpdate(puntos_estimacion);
                puntos_estimacionRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /PUNTOS_ESTIMACION/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(puntos_estimacionRepository.Find(id));
        }

        //
        // POST: /PUNTOS_ESTIMACION/Edit/5

        [HttpPost]
        public ActionResult Edit(PUNTOS_ESTIMACION puntos_estimacion)
        {
            if (ModelState.IsValid) {
                puntos_estimacionRepository.InsertOrUpdate(puntos_estimacion);
                puntos_estimacionRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /PUNTOS_ESTIMACION/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(puntos_estimacionRepository.Find(id));
        }

        //
        // POST: /PUNTOS_ESTIMACION/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            puntos_estimacionRepository.Delete(id);
            puntos_estimacionRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                puntos_estimacionRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

