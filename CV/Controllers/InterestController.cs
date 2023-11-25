using CV.Models.Entity;
using CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Controllers
{
    public class InterestController : Controller
    {
        // GET: Interests
        GenericRepository<Interests> repository = new GenericRepository<Interests>();
        [HttpGet]
        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(Interests t)
        {
            //Interests ınterests = new Interests();
            var ınterests = repository.GetByID(x => x.ID == 1);
            ınterests.Description1 = t.Description1;
            ınterests.Description2 = t.Description2;
            repository.TUpdate(ınterests);
            return RedirectToAction("Index");   
        }
    }
}