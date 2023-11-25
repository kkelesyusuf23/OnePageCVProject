using CV.Models.Entity;
using CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Login> repository = new GenericRepository<Login>();

        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Login login)
        {
            repository.TAdd(login);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            Login t = repository.GetByID(x => x.ID == id);
            repository.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            Login t = repository.GetByID(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Login t)
        {
            Login login = repository.GetByID(x => x.ID == t.ID);
            login.Username = t.Username;
            login.Password = t.Password;
            repository.TUpdate(login);
            return RedirectToAction("Index");
        }
    }
}