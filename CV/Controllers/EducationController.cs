using CV.Models.Entity;
using CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Controllers
{
    //[Authorize] controller bazında authorize etme
    public class EducationController : Controller
    {
        // GET: Education
        DBCvEntities dB = new DBCvEntities();
        GenericRepository<Educations> repository = new GenericRepository<Educations>();
        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(Educations educations)
        {
            if (!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repository.TAdd(educations);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            var value = repository.GetByID(x => x.ID == id);
            repository.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var education = repository.GetByID(x => x.ID == id);
            return View(education);
        }
        [HttpPost]
        public ActionResult UpdateEducation(Educations t)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateEducation");
            }
            var education = repository.GetByID(x => x.ID == t.ID);
            education.Title = t.Title;
            education.SubTitle1 = t.SubTitle1;
            education.SubTitle2 = t.SubTitle2;
            education.Date = t.Date;
            education.GNO = t.GNO;
            repository.TUpdate(education);
            return RedirectToAction("Index");
        }
    }
}