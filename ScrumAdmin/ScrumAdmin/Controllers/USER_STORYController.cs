using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumAdmin.Models;

namespace ScrumAdmin.Controllers
{   
    public class USER_STORYController : Controller
    {
		private readonly IUSER_STORYRepository user_storyRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public USER_STORYController() : this(new USER_STORYRepository())
        {
        }

        public USER_STORYController(IUSER_STORYRepository user_storyRepository)
        {
			this.user_storyRepository = user_storyRepository;
        }

        //
        // GET: /USER_STORY/

        public ViewResult Index()
        {
            return View(user_storyRepository.AllIncluding(user_story => user_story.TAREA));
        }

        //
        // GET: /USER_STORY/Details/5

        public ViewResult Details(int id)
        {
            return View(user_storyRepository.Find(id));
        }

        //
        // GET: /USER_STORY/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /USER_STORY/Create

        [HttpPost]
        public ActionResult Create(USER_STORY user_story)
        {
            if (ModelState.IsValid) {
                user_storyRepository.InsertOrUpdate(user_story);
                user_storyRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /USER_STORY/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(user_storyRepository.Find(id));
        }

        //
        // POST: /USER_STORY/Edit/5

        [HttpPost]
        public ActionResult Edit(USER_STORY user_story)
        {
            if (ModelState.IsValid) {
                user_storyRepository.InsertOrUpdate(user_story);
                user_storyRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /USER_STORY/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(user_storyRepository.Find(id));
        }

        //
        // POST: /USER_STORY/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            user_storyRepository.Delete(id);
            user_storyRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                user_storyRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

