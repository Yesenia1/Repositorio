using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumAdmin.Models;

namespace ScrumAdmin.Controllers
{   
    public class EQUIPOController : Controller
    {
		private readonly IEQUIPORepository equipoRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public EQUIPOController() : this(new EQUIPORepository())
        {
        }

        public EQUIPOController(IEQUIPORepository equipoRepository)
        {
			this.equipoRepository = equipoRepository;
        }

        //
        // GET: /EQUIPO/

        public ViewResult Index()
        {
            return View(equipoRepository.AllIncluding(equipo => equipo.USER_STORY));
        }

        //
        // GET: /EQUIPO/Details/5

        public ViewResult Details(int id)
        {
            return View(equipoRepository.Find(id));
        }

        //
        // GET: /EQUIPO/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /EQUIPO/Create

        [HttpPost]
        public ActionResult Create(EQUIPO equipo)
        {
            if (ModelState.IsValid) {
                equipoRepository.InsertOrUpdate(equipo);
                equipoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /EQUIPO/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(equipoRepository.Find(id));
        }

        //
        // POST: /EQUIPO/Edit/5

        [HttpPost]
        public ActionResult Edit(EQUIPO equipo)
        {
            if (ModelState.IsValid) {
                equipoRepository.InsertOrUpdate(equipo);
                equipoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /EQUIPO/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(equipoRepository.Find(id));
        }

        //
        // POST: /EQUIPO/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            equipoRepository.Delete(id);
            equipoRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                equipoRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

