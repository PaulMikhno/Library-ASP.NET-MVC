using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Library.BLL.Servises;
using Library.BLL.Interfaces;
using System.Configuration;
using AutoMapper;
using Library.WEB.Models;
using ViewEntities.Models;
using ViewEntities.Enums;

namespace Library.WEB.Controllers
{
    [Authorize]
    public class BrochureController : Controller
    {

        BrochureService brochureService;

        public BrochureController()
        {
            brochureService = new BrochureService(ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString);
           
        }

        public ActionResult Brochures()
        {
            
            return View(brochureService.Get());
           
        }

        [Authorize(Roles = nameof(IdentityViewRoles.Admin))]
        [HttpPost]
        public ActionResult AddBrochure(BrochureViewModel brochure)
        {
            brochureService.Create(brochure);
           

            return Json(brochure, JsonRequestBehavior.AllowGet);

        }

        [Authorize(Roles = nameof(IdentityViewRoles.Admin))]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            BrochureViewModel b = brochureService.Get(id);
            if (b == null)
            {
                return HttpNotFound();
            }

            brochureService.Remove(id);

            return RedirectToAction("Brochures");
        }

        [Authorize(Roles = nameof(IdentityViewRoles.Admin))]
        [HttpPost]
        public ActionResult EditBrochure(BrochureViewModel brochure)
        {

            if (brochure == null)
            {
                return HttpNotFound();
            }
            brochureService.Update(brochure);
            return Json(brochure);
        }
        
        public JsonResult GetBrochures(string text)
        {
            var brochures = brochureService.Get();
            
            return this.Json(brochures, JsonRequestBehavior.AllowGet);
        }

       
    }
}