using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumAdmin.Models;

namespace ScrumAdmin.Controllers
{   
    public class STAKEHOLDERController : Controller
    {
		private readonly ISTAKEHOLDERRepository stakeholderRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public STAKEHOLDERController() : this(new STAKEHOLDERRepository())
        {
        }

        public STAKEHOLDERController(ISTAKEHOLDERRepository stakeholderRepository)
        {
			this.stakeholderRepository = stakeholderRepository;
        }

        //
        // GET: /STAKEHOLDER/

        public ViewResult Index()
        {
            return View(stakeholderRepository.All);
        }

        //
        // GET: /STAKEHOLDER/Details/5

        public ViewResult Details(int id)
        {
            return View(stakeholderRepository.Find(id));
        }

        //
        // GET: /STAKEHOLDER/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /STAKEHOLDER/Create

        [HttpPost]
        public ActionResult Create(STAKEHOLDER stakeholder)
        {
            if (ModelState.IsValid) {
                stakeholderRepository.InsertOrUpdate(stakeholder);
                stakeholderRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /STAKEHOLDER/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(stakeholderRepository.Find(id));
        }

        //
        // POST: /STAKEHOLDER/Edit/5

        [HttpPost]
        public ActionResult Edit(STAKEHOLDER stakeholder)
        {
            if (ModelState.IsValid) {
                stakeholderRepository.InsertOrUpdate(stakeholder);
                stakeholderRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /STAKEHOLDER/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(stakeholderRepository.Find(id));
        }

        //
        // POST: /STAKEHOLDER/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            stakeholderRepository.Delete(id);
            stakeholderRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                stakeholderRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

