using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumAdmin.Models;

namespace ScrumAdmin.Controllers
{
    [Authorize]
    public class USUARIOController : Controller
    {
		private readonly IUSUARIORepository usuarioRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public USUARIOController() : this(new USUARIORepository())
        {
        }

        public USUARIOController(IUSUARIORepository usuarioRepository)
        {
			this.usuarioRepository = usuarioRepository;
        }

        //
        // GET: /USUARIO/

        public ViewResult Index()
        {
            return View(usuarioRepository.AllIncluding(usuario => usuario.EQUIPO));
        }

        //
        // GET: /USUARIO/Details/5

        public ViewResult Details(int id)
        {
            return View(usuarioRepository.Find(id));
        }

        //
        // GET: /USUARIO/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /USUARIO/Create

        [HttpPost]
        public ActionResult Create(USUARIO usuario)
        {
            if (ModelState.IsValid) {
                usuarioRepository.InsertOrUpdate(usuario);
                usuarioRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /USUARIO/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(usuarioRepository.Find(id));
        }

        //
        // POST: /USUARIO/Edit/5

        [HttpPost]
        public ActionResult Edit(USUARIO usuario)
        {
            if (ModelState.IsValid) {
                usuarioRepository.InsertOrUpdate(usuario);
                usuarioRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /USUARIO/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(usuarioRepository.Find(id));
        }

        //
        // POST: /USUARIO/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            usuarioRepository.Delete(id);
            usuarioRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                usuarioRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

