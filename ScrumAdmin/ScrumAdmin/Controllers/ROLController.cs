using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumAdmin.Models;

namespace ScrumAdmin.Controllers
{   
    public class ROLController : Controller
    {
		private readonly IROLRepository rolRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ROLController() : this(new ROLRepository())
        {
        }

        public ROLController(IROLRepository rolRepository)
        {
			this.rolRepository = rolRepository;
        }

        //
        // GET: /ROL/

        public ViewResult Index()
        {
            return View(rolRepository.AllIncluding(rol => rol.EQUIPO));
        }

        //
        // GET: /ROL/Details/5

        public ViewResult Details(int id)
        {
            return View(rolRepository.Find(id));
        }

        //
        // GET: /ROL/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ROL/Create

        [HttpPost]
        public ActionResult Create(ROL rol)
        {
            if (ModelState.IsValid) {
                rolRepository.InsertOrUpdate(rol);
                rolRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /ROL/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(rolRepository.Find(id));
        }

        //
        // POST: /ROL/Edit/5

        [HttpPost]
        public ActionResult Edit(ROL rol)
        {
            if (ModelState.IsValid) {
                rolRepository.InsertOrUpdate(rol);
                rolRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /ROL/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(rolRepository.Find(id));
        }

        //
        // POST: /ROL/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            rolRepository.Delete(id);
            rolRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                rolRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

