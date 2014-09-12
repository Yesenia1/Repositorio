using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumAdmin.Models;

namespace ScrumAdmin.Controllers
{   
    public class TIPOController : Controller
    {
		private readonly ITIPORepository tipoRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public TIPOController() : this(new TIPORepository())
        {
        }

        public TIPOController(ITIPORepository tipoRepository)
        {
			this.tipoRepository = tipoRepository;
        }

        //
        // GET: /TIPO/

        public ViewResult Index()
        {
            return View(tipoRepository.AllIncluding(tipo => tipo.USER_STORY));
        }

        //
        // GET: /TIPO/Details/5

        public ViewResult Details(int id)
        {
            return View(tipoRepository.Find(id));
        }

        //
        // GET: /TIPO/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TIPO/Create

        [HttpPost]
        public ActionResult Create(TIPO tipo)
        {
            if (ModelState.IsValid) {
                tipoRepository.InsertOrUpdate(tipo);
                tipoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /TIPO/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(tipoRepository.Find(id));
        }

        //
        // POST: /TIPO/Edit/5

        [HttpPost]
        public ActionResult Edit(TIPO tipo)
        {
            if (ModelState.IsValid) {
                tipoRepository.InsertOrUpdate(tipo);
                tipoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /TIPO/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(tipoRepository.Find(id));
        }

        //
        // POST: /TIPO/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoRepository.Delete(id);
            tipoRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                tipoRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

