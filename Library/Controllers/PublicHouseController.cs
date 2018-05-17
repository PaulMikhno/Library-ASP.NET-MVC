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
using ViewEntities.Models;

namespace Library.WEB.Controllers
{
    [Authorize]
    public class PublicHouseController : Controller
    {
        PublicationHouseService publicHouseService;
      
       

        public PublicHouseController()
        {
            publicHouseService = new PublicationHouseService(ConfigurationManager.ConnectionStrings["LibraryContext"].ConnectionString);
            
        }

        public ActionResult PublicHouses()
        {

            return View(publicHouseService.Get());
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AddPublicHouse(PublicHouseViewModel publicHouse)
        {
            if (publicHouse.Name == null)
            {
                throw new ArgumentNullException(nameof(publicHouse));
            }

            publicHouseService.Create(publicHouse);
          
            return Json(publicHouse);

        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            PublicHouseViewModel b = publicHouseService.Get(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            publicHouseService.Remove(id);

            return RedirectToAction("PublicHouses");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditPublicHouse(PublicHouseViewModel publicHouse)
        {
            if (publicHouse.Name == null)
            {
                return HttpNotFound();
            }
            publicHouseService.Update(publicHouse);
            return Json(publicHouse);
        }
        
        public JsonResult GetPublicationHouses(string text)
        {
            var  publicHouses = publicHouseService.Get();
            return this.Json(
           (from obj in publicHouses select new { Id = obj.Id, Name = obj.Name, Address=obj.Address })
           , JsonRequestBehavior.AllowGet
           );
        }
        
    }
}
