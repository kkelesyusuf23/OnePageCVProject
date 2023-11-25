using CV.Models.Entity;
using CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        DBCvEntities dB = new DBCvEntities();
        GenericRepository<Certificates> repository = new GenericRepository<Certificates>();
        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateCertificate(int id)
        {
            var certificate = repository.GetByID(x => x.ID == id);
            ViewBag.d = id;
            return View(certificate);
        }
        [HttpPost]
        public ActionResult UpdateCertificate(Certificates t)
        {
            var certificate = repository.GetByID(x => x.ID == t.ID);
            certificate.Description = t.Description;
            certificate.Date = t.Date;
            repository.TUpdate(certificate);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCertificate(Certificates t)
        {
            repository.TAdd(t);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCertificate(int id)
        {
            var value = repository.GetByID(x => x.ID == id);
            repository.TDelete(value);
            return RedirectToAction("Index");   
        }
    }
}