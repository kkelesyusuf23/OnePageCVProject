using CV.Models.Entity;
using CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        DBCvEntities dB = new DBCvEntities();
        GenericRepository<Abouts> repository = new GenericRepository<Abouts>();
        [HttpGet]
        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(Abouts t)
        {
            var ınterests = repository.GetByID(x => x.ID == 1);
            ınterests.Name = t.Name;
            ınterests.Surname = t.Surname;
            ınterests.Address = t.Address;
            ınterests.Mail = t.Mail;
            ınterests.Telefon= t.Telefon;
            ınterests.Description = t.Description;
            ınterests.Image = t.Image;
            repository.TUpdate(ınterests);
            return RedirectToAction("Index");
        }
    }
}