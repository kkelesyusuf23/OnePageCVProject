using CV.Models.Entity;
using CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        GenericRepository<SocialMedia> repository = new GenericRepository<SocialMedia>();
        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(SocialMedia t)
        {
            repository.TAdd(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var socialMedia = repository.GetByID(x => x.ID == id);
            return View(socialMedia);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia t)
        {
            var socialMedia = repository.GetByID(x => x.ID == t.ID);
            socialMedia.SocialMediaName = t.SocialMediaName;
            socialMedia.Link = t.Link;
            socialMedia.Icon = t.Icon;
            socialMedia.Statu = true;
            repository.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var hesap = repository.GetByID(x => x.ID == id);
            hesap.Statu = false;
            repository.TUpdate(hesap);
            return RedirectToAction("Index");
        }
    }
}