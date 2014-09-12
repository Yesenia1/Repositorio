using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScrumAdmin.Models;

namespace ScrumAdmin.Controllers
{   
    public class PROYECTOController : Controller
    {
		private readonly IPROYECTORepository proyectoRepository;
        private readonly IEQUIPORepository miembrosRepository;
        private static int tmpIdProyecto;
        public Entities db = new Entities();
        SINGLETON singleton = SINGLETON.Create();

		// If you are using Dependency Injection, you can delete the following constructor
        public PROYECTOController() : this(new PROYECTORepository())
        {
        }

        public PROYECTOController(IPROYECTORepository proyectoRepository)
        {
			this.proyectoRepository = proyectoRepository;
        }

        //
        // GET: /PROYECTO/

        public ViewResult Index()
        {
            return View(proyectoRepository.AllIncluding(proyecto => proyecto.CRITERIOS_ACEPTACION, proyecto => proyecto.EQUIPO, proyecto => proyecto.RELEASE, proyecto => proyecto.RIESGO, proyecto => proyecto.STAKEHOLDER));
        }

        //
        // GET: /PROYECTO/Details/5

        public ViewResult Details(int id)
        {
            return View(proyectoRepository.Find(id));
        }

        //
        // GET: /PROYECTO/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /PROYECTO/Create

        [HttpPost]
        public ActionResult Create(PROYECTO proyecto)
        {
            if (ModelState.IsValid) {
                proyectoRepository.InsertOrUpdate(proyecto);
                proyectoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /PROYECTO/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(proyectoRepository.Find(id));
        }

        //
        // POST: /PROYECTO/Edit/5

        [HttpPost]
        public ActionResult Edit(PROYECTO proyecto)
        {
            if (ModelState.IsValid) {
                proyectoRepository.InsertOrUpdate(proyecto);
                proyectoRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /PROYECTO/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(proyectoRepository.Find(id));
        }

        //
        // POST: /PROYECTO/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            proyectoRepository.Delete(id);
            proyectoRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                proyectoRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        ////EQUIPO !!!

        //
        // GET: /Equipo/

        public ActionResult IndexEquipo(int id)
        {
            tmpIdProyecto = new int();
            tmpIdProyecto = id;
            return View(db.EQUIPO.Where(e => e.IDPROYECTO == id));
        }

        //
        // GET: /EQUIPO/Create

        public ActionResult CreateMiembro()
        {            
            ViewBag.IDUSUARIO = new SelectList(db.USUARIO, "ID", "EMAIL");
            ViewBag.IDROL = new SelectList(db.ROL, "ID", "NOMBRE");
            return View();
        }

        //
        // POST: /EQUIPO/Create

        [HttpPost]
        public ActionResult CreateMiembro(EQUIPO equipo)
        {
            if (ModelState.IsValid)
            {
                equipo.IDPROYECTO = tmpIdProyecto;
                db.EQUIPO.Add(equipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.IDUSUARIO = new SelectList(db.USUARIO, "ID", "EMAIL", equipo.IDUSUARIO);
                ViewBag.IDROL = new SelectList(db.ROL, "ID", "NOMBRE", equipo.IDROL);
                return View();
            }
        }


        //////User Story
        public ActionResult IndexStory(int id)
        {
            singleton.idProyecto = id;
            return RedirectToAction("Index", "USER_STORY");
        }

    }
}

