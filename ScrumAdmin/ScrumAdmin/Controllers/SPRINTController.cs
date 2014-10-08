using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumAdmin.Models;

namespace ScrumAdmin.Controllers
{
    [Authorize]
    public class SPRINTController : Controller
    {
		private readonly ISPRINTRepository sprintRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public SPRINTController() : this(new SPRINTRepository())
        {
        }

        public SPRINTController(ISPRINTRepository sprintRepository)
        {
			this.sprintRepository = sprintRepository;
        }

        //
        // GET: /SPRINT/

        public ViewResult Index()
        {
            return View(sprintRepository.AllIncluding(sprint => sprint.SPRINT_RETROSPECTIVE, sprint => sprint.SPRINT_REVIEW, sprint => sprint.USER_STORY));
        }

        //
        // GET: /SPRINT/Details/5

        public ViewResult Details(int id)
        {
            return View(sprintRepository.Find(id));
        }

        //
        // GET: /SPRINT/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /SPRINT/Create

        [HttpPost]
        public ActionResult Create(SPRINT sprint)
        {
            if (ModelState.IsValid) {
                sprintRepository.InsertOrUpdate(sprint);
                sprintRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /SPRINT/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(sprintRepository.Find(id));
        }

        //
        // POST: /SPRINT/Edit/5

        [HttpPost]
        public ActionResult Edit(SPRINT sprint)
        {
            if (ModelState.IsValid) {
                sprintRepository.InsertOrUpdate(sprint);
                sprintRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /SPRINT/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(sprintRepository.Find(id));
        }

        //
        // POST: /SPRINT/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            sprintRepository.Delete(id);
            sprintRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                sprintRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

