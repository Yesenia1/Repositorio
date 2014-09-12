using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumAdmin.Models;

namespace ScrumAdmin.Controllers
{   
    public class RELEASEController : Controller
    {
		private readonly IRELEASERepository releaseRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public RELEASEController() : this(new RELEASERepository())
        {
        }

        public RELEASEController(IRELEASERepository releaseRepository)
        {
			this.releaseRepository = releaseRepository;
        }

        //
        // GET: /RELEASE/

        public ViewResult Index()
        {
            return View(releaseRepository.AllIncluding(release => release.SPRINT));
        }

        //
        // GET: /RELEASE/Details/5

        public ViewResult Details(int id)
        {
            return View(releaseRepository.Find(id));
        }

        //
        // GET: /RELEASE/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /RELEASE/Create

        [HttpPost]
        public ActionResult Create(RELEASE release)
        {
            if (ModelState.IsValid) {
                releaseRepository.InsertOrUpdate(release);
                releaseRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /RELEASE/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(releaseRepository.Find(id));
        }

        //
        // POST: /RELEASE/Edit/5

        [HttpPost]
        public ActionResult Edit(RELEASE release)
        {
            if (ModelState.IsValid) {
                releaseRepository.InsertOrUpdate(release);
                releaseRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /RELEASE/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(releaseRepository.Find(id));
        }

        //
        // POST: /RELEASE/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            releaseRepository.Delete(id);
            releaseRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                releaseRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

