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
        private readonly ITAREARepository tareasRepository;
        private static int tmpIdUserStory;
        public Entities db = new Entities();
        SINGLETON singleton = SINGLETON.Create();

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
            var query = from u in db.USER_STORY
                        join e in db.EQUIPO
                        on u.PROPIETARIO equals e.ID
                        where (e.IDPROYECTO == singleton.idProyecto)
                        select u;

            return View(query);
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
            //para usuarios de un unico proyecto
            var query = from u in db.USUARIO
                        join e in db.EQUIPO
                        on u.ID equals e.IDUSUARIO
                        where (e.IDROL == 1) || (e.IDROL == 2)
                        select new { u.NICK, u.AP1, u.EMAIL, e.ID, e.IDPROYECTO, e.IDROL, e.IDUSUARIO };

            ViewBag.IDPUNTOSESTIM = new SelectList(db.PUNTOS_ESTIMACION, "ID", "NOMBRE");
            ViewBag.IDPRIORIDAD = new SelectList(db.PRIORIDAD, "ID", "NOMBRE");
            ViewBag.IDESTADO = new SelectList(db.ESTADO, "ID", "NOMBRE");
            ViewBag.IDTIPO = new SelectList(db.TIPO, "ID", "NOMBRE");
            ViewBag.PROPIETARIO = new SelectList(query, "ID", "EMAIL");
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
            }else {
                var query = from u in db.USUARIO
                            join e in db.EQUIPO
                            on u.ID equals e.IDUSUARIO
                            select new { u.NICK, u.AP1, u.EMAIL, e.ID, e.IDPROYECTO, e.IDROL, e.IDUSUARIO };
                ViewBag.IDPUNTOSESTIM = new SelectList(db.PUNTOS_ESTIMACION, "ID", "NOMBRE", user_story.IDPUNTOSESTIM);
                ViewBag.IDPRIORIDAD = new SelectList(db.PRIORIDAD, "ID", "NOMBRE", user_story.IDPRIORIDAD);
                ViewBag.IDESTADO = new SelectList(db.ESTADO, "ID", "NOMBRE", user_story.IDESTADO);
                ViewBag.IDTIPO = new SelectList(db.TIPO, "ID", "NOMBRE", user_story.IDTIPO);
                ViewBag.PROPIETARIO = new SelectList(query, "ID", "EMAIL", user_story.PROPIETARIO);
                return View();
            }
        }
        
        //
        // GET: /USER_STORY/Edit/5
 
        public ActionResult Edit(int id)
        {
            var query = from u in db.USUARIO
                        join e in db.EQUIPO
                        on u.ID equals e.IDUSUARIO
                        select new { u.NICK, u.AP1, u.EMAIL, e.ID, e.IDPROYECTO, e.IDROL, e.IDUSUARIO };
            USER_STORY us = db.USER_STORY.Single(c => c.ID == id);

            ViewBag.IDPUNTOSESTIM = new SelectList(db.PUNTOS_ESTIMACION, "ID", "NOMBRE", us.IDPUNTOSESTIM);
            ViewBag.IDPRIORIDAD = new SelectList(db.PRIORIDAD, "ID", "NOMBRE", us.IDPRIORIDAD);
            ViewBag.IDESTADO = new SelectList(db.ESTADO, "ID", "NOMBRE", us.IDESTADO);
            ViewBag.IDTIPO = new SelectList(db.TIPO, "ID", "NOMBRE", us.IDTIPO);
            ViewBag.PROPIETARIO = new SelectList(query, "ID", "EMAIL", us.PROPIETARIO);
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
                var query = from u in db.USUARIO
                            join e in db.EQUIPO
                            on u.ID equals e.IDUSUARIO
                            select new { u.NICK, u.AP1, u.EMAIL, e.ID, e.IDPROYECTO, e.IDROL, e.IDUSUARIO };
                ViewBag.IDPUNTOSESTIM = new SelectList(db.PUNTOS_ESTIMACION, "ID", "NOMBRE", user_story.IDPUNTOSESTIM);
                ViewBag.IDPRIORIDAD = new SelectList(db.PRIORIDAD, "ID", "NOMBRE", user_story.IDPRIORIDAD);
                ViewBag.IDESTADO = new SelectList(db.ESTADO, "ID", "NOMBRE", user_story.IDESTADO);
                ViewBag.IDTIPO = new SelectList(db.TIPO, "ID", "NOMBRE", user_story.IDTIPO);
                ViewBag.PROPIETARIO = new SelectList(query, "ID", "EMAIL", user_story.PROPIETARIO);
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

        ////TAREAS !!!

        //
        // GET: /TAREA/

        public ActionResult Index_Tareas(int id)
        {
            tmpIdUserStory = new int(); 
            tmpIdUserStory = id;
            return View(db.TAREA.Where(e => e.IDUSERSTORY == id));
        }

        //
        // GET: /TAREA/Create

        public ActionResult CreateTarea()
        {            
            return View();
        }

        //
        // POST: /TAREA/Create

        [HttpPost]
        public ActionResult CreateTarea(TAREA tarea)
        {
            if (ModelState.IsValid){
                tarea.IDUSERSTORY = tmpIdUserStory;
                db.TAREA.Add(tarea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }





    }
}

