using CV.Models.Entity;
using CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skıll
        DBCvEntities dB = new DBCvEntities();
        GenericRepository<Skills> repository = new GenericRepository<Skills>(); 
        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        public ActionResult AddSkill(Skills skills)
        {
            repository.TAdd(skills);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            var value = repository.GetByID(x => x.ID == id);
            repository.TDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var value = repository.GetByID(x => x.ID == id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSkill(Skills skills)
        {
            var value = repository.GetByID(x => x.ID == skills.ID);
            value.Skill = skills.Skill;
            value.Progress = skills.Progress;
            repository.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}