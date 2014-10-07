using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrumAdmin.Controllers
{
    public class HomeController : Controller
    {
        //
        //GET: /Home/
        public ActionResult Index()
        {
            ViewBag.Message = "Sistema administrador de Metodlogia SCRUM";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult GetData()
        { 
            return Json (CreateSprintList(), JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<BurnDown> CreateSprintList()
        {
            List<BurnDown> data = new List<BurnDown>();

            BurnDown sprint1 = new BurnDown() { Expensive = 1, Salary = 9, Year = new DateTime(2012, 1, 1).ToString("yyyy/MM") };
            BurnDown sprint2 = new BurnDown() { Expensive = 2, Salary = 10, Year = new DateTime(2012, 2, 1).ToString("yyyy/MM") };
            BurnDown sprint3 = new BurnDown() { Expensive = 3, Salary = 12, Year = new DateTime(2012, 3, 1).ToString("yyyy/MM") };

            data.Add(sprint1);
            data.Add(sprint2);
            data.Add(sprint3);

            return data;
        }
    }
}
