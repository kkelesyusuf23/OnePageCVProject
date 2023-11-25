using CV.Models.Entity;
using CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        GenericRepository<Contacts> repository = new GenericRepository<Contacts>();
        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }
    }
}