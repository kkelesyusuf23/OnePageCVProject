using CV.Models.Entity;
using CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repository = new ExperienceRepository();
        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(Experiences experiences)
        {
            repository.TAdd(experiences);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id)
        {
            Experiences t = repository.GetByID(x => x.ID == id);
            repository.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            Experiences t = repository.GetByID(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult UpdateExperience(Experiences experiences)
        {
            Experiences t = repository.GetByID(x => x.ID == experiences.ID);
            t.Title = experiences.Title;
            t.SubTitle = experiences.SubTitle;
            t.Date = experiences.Date;
            t.Description = experiences.Description;
            repository.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}