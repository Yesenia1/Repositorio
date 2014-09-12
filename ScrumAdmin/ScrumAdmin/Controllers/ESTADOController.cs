using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumAdmin.Models;

namespace ScrumAdmin.Controllers
{   
    public class ESTADOController : Controller
    {
		private readonly IESTADORepository estadoRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public ESTADOController() : this(new ESTADORepository())
        {
        }

        public ESTADOController(IESTADORepository estadoRepository)
        {
			this.estadoRepository = estadoRepository;
        }

        //
        // GET: /ESTADO/

        public ViewResult Index()
        {
            return View(estadoRepository.AllIncluding(estado => estado.USER_STORY));
        }

        //
        // GET: /ESTADO/Details/5

        public ViewResult Details(int id)
        {
            return View(estadoRepository.Find(id));
        }

        //
        // GET: /ESTADO/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ESTADO/Create

        [HttpPost]
        public ActionResult Create(ESTADO estado)
        {
            if (ModelState.IsValid) {
                estadoRepository.InsertOrUpdate(estado);
                estadoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /ESTADO/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(estadoRepository.Find(id));
        }

        //
        // POST: /ESTADO/Edit/5

        [HttpPost]
        public ActionResult Edit(ESTADO estado)
        {
            if (ModelState.IsValid) {
                estadoRepository.InsertOrUpdate(estado);
                estadoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /ESTADO/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(estadoRepository.Find(id));
        }

        //
        // POST: /ESTADO/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            estadoRepository.Delete(id);
            estadoRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                estadoRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

