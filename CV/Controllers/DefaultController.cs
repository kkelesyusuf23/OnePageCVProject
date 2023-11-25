using CV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DBCvEntities db = new DBCvEntities();
        public ActionResult Index()
        {
            var values = db.Abouts.ToList();
            return View(values);
        }
        public PartialViewResult SocialMedia()
        {
            var values = db.SocialMedia.Where(x => x.Statu == true).ToList();
            return PartialView(values);
        }
        public PartialViewResult About()
        {
            var values = db.Abouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult Experience()
        {
            var values = db.Experiences.OrderByDescending(x => x.ID).ToList();
            return PartialView(values);
        }
        public PartialViewResult Education()
        {
            var values = db.Educations.ToList();
            return PartialView(values);
        }
        public PartialViewResult Skılls()
        {
            var values = db.Skills.ToList();
            return PartialView(values);
        }
        public PartialViewResult Interests()
        {
            var values = db.Interests.ToList();
            return PartialView(values);
        }
        public PartialViewResult Certificates()
        {
            var values = db.Certificates.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult Contacts()
        {
            return PartialView();
        }   
        [HttpPost]
        public PartialViewResult Contacts(Contacts contacts)
        {
            contacts.Date =DateTime.Parse( DateTime.Now.ToShortDateString());
            db.Contacts.Add(contacts);
            db.SaveChanges();
            return PartialView();
        }
    }
}