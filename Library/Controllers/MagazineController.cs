using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
//using Library.Entities.Models;
using Library.BLL;
using Library.BLL.Interfaces;
using Library.BLL.Servises;
using System.Configuration;
using ViewEntities.Models;

namespace Library.WEB.Controllers
{
    [Authorize]
    public class MagazineController : Controller
    {

        MagazineService magazineService;
        public MagazineController()
        {
            magazineService = new MagazineService(ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString);
           
        }

        public ActionResult Magazines()
        {

            return View(magazineService.Get());
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AddMagazine(MagazineViewModel magazine)
        {
            magazineService.Create(magazine);
            
            return Json(magazine, JsonRequestBehavior.AllowGet);

        }
        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            MagazineViewModel b = magazineService.Get(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            magazineService.Remove(id);

            return RedirectToAction("Magazines");
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditMagazine(MagazineViewModel magazine)
        {

            if (magazine == null)
            {
                return HttpNotFound();
            }
            magazineService.Update(magazine);
            return Json(magazine);
        }
        
        public JsonResult GetMagazines(string text)
        {
            var magazines = magazineService.Get();
            return this.Json(magazines, JsonRequestBehavior.AllowGet);
        }
    }

    //[HttpGet]
    //public ActionResult Download(int id)
    //{
    //    Magazine b = magazineService.Get(id);
    //    if (b == null)
    //    {
    //        return HttpNotFound();
    //    }
    //    return View(b);
    //}

    //[HttpPost, ActionName("Download")]
    //public ActionResult DownloadConfirmed(int id)
    //{
    //    Magazine b = magazineService.Get(id);
    //    if (b == null)
    //    {
    //        return HttpNotFound();
    //    }
    //    logic.Download(b);
    //    return RedirectToAction("Magazines");
    //}
}